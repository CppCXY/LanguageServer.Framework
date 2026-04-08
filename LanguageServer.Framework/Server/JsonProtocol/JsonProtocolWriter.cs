using System.Buffers;
using System.Text;
using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;
using EmmyLua.LanguageServer.Framework.Server.Metrics;

namespace EmmyLua.LanguageServer.Framework.Server.JsonProtocol;

public class JsonProtocolWriter : IDisposable
{
    private readonly Stream _output;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly SemaphoreSlim _writeLock = new(1, 1);
    private bool _disposed;

    /// <summary>
    /// Performance metrics collector
    /// </summary>
    public IPerformanceMetricsCollector? MetricsCollector { get; set; }

    public JsonProtocolWriter(Stream output, JsonSerializerOptions jsonSerializerOptions)
    {
        _output = output;
        _jsonSerializerOptions = jsonSerializerOptions;
    }

    public void WriteResponse(StringOrInt id, JsonDocument? document, ResponseError? error = null)
    {
        var response = new ResponseMessage(id, document, error);
        WriteMessage(response);
    }

    public void WriteShutdownResponse(StringOrInt id)
    {
        var response = new ShutdownResponseMessage(id);
        WriteMessage(response);
    }

    public void WriteNotification(NotificationMessage message)
    {
        WriteMessage(message);
    }

    public void WriteRequest(RequestMessage message)
    {
        WriteMessage(message);
    }

    private void WriteMessage<T>(T message)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);

        // Use thread-safe writing
        _writeLock.Wait();
        try
        {
            // Serialize to memory
            var json = JsonSerializer.Serialize(message, _jsonSerializerOptions);
            var contentLength = Encoding.UTF8.GetByteCount(json);

            // Calculate header size
            var headerText = $"Content-Length: {contentLength}\r\n\r\n";
            var headerBytes = Encoding.UTF8.GetByteCount(headerText);

            // Use ArrayPool to reduce allocations
            var totalLength = headerBytes + contentLength;
            var buffer = ArrayPool<byte>.Shared.Rent(totalLength);

            try
            {
                // Write header
                var written = Encoding.UTF8.GetBytes(headerText, buffer);

                // Write content
                written += Encoding.UTF8.GetBytes(json, buffer.AsSpan(written));

                // Write to stream at once
                _output.Write(buffer, 0, written);
                _output.Flush();

                // Record message sent
                MetricsCollector?.RecordMessageSent();
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
        finally
        {
            _writeLock.Release();
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _writeLock.Dispose();
    }
}
