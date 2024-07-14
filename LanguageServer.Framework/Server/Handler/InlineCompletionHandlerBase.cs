using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class InlineCompletionHandlerBase : IJsonHandler
{
    protected abstract Task<InlineCompletionResponse> Handle(InlineCompletionParams request,
        CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
         server.AddRequestHandler("textDocument/inlineCompletion", async (message, token) =>
         {
             var request = message.Params!.Deserialize<InlineCompletionParams>(server.JsonSerializerOptions)!;
             var r = await Handle(request, token);
             return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
         });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
