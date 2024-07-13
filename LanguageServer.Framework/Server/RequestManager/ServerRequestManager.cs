using System.Collections.Concurrent;
using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Server.RequestManager;

public class ServerRequestManager
{
    private ConcurrentDictionary<int, TaskCompletionSource<JsonDocument?>> _intRequestTokens = new();

    private int _idCount = 0;

    public RequestMessage MakeRequest(string method, JsonDocument? @params)
    {
        var id = Interlocked.Increment(ref _idCount);
        _intRequestTokens[id] = new TaskCompletionSource<JsonDocument?>();
        return new RequestMessage(id, method, @params);
    }

    public void OnResponse(StringOrInt id, JsonDocument? response)
    {
        if (id.StringValue is null)
        {
            var intId = id.IntValue;
            if (_intRequestTokens.TryRemove(intId, out var tcs))
            {
                tcs.SetResult(response);
            }
        }
    }

    public async Task<JsonDocument?> WaitResponse(StringOrInt id, CancellationToken token)
    {
        if (id.StringValue is null)
        {
            var intId = id.IntValue;
            if (_intRequestTokens.TryGetValue(intId, out var tcs))
            {
                await using (token.Register(() => tcs.TrySetCanceled()))
                {
                    return await tcs.Task;
                }
            }
        }

        throw new InvalidOperationException("Invalid response id");
    }
}
