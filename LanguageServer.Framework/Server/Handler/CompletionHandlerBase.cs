using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class CompletionHandlerBase : IJsonHandler
{
    protected abstract Task<CompletionResponse?> Handle(CompletionParams request, CancellationToken token);

    protected abstract Task<CompletionItem> Resolve(CompletionItem item, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/completion", async (message, token) =>
        {
            var request = message.Params!.Deserialize<CompletionParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });

        server.AddRequestHandler("completionItem/resolve", async (message, token) =>
        {
            var item = message.Params!.Deserialize<CompletionItem>(server.JsonSerializerOptions)!;
            var r = await Resolve(item, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
