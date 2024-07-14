using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class DocumentColorHandlerBase : IJsonHandler
{
    protected abstract Task<DocumentColorResponse> Handle(DocumentColorParams request, CancellationToken token);

    protected abstract Task<ColorPresentationResponse> Resolve(ColorPresentationParams request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/documentColor", async (message, token) =>
        {
            var request = message.Params!.Deserialize<DocumentColorParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });

        server.AddRequestHandler("textDocument/colorPresentation", async (message, token) =>
        {
            var request = message.Params!.Deserialize<ColorPresentationParams>(server.JsonSerializerOptions)!;
            var r = await Resolve(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
