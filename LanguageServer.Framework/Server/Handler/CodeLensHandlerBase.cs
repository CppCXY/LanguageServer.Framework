using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.CodeLens;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class CodeLensHandlerBase : IJsonHandler
{
    protected abstract Task<CodeLensResponse> Handle(CodeLensParams request, CancellationToken token);

    protected abstract Task<CodeLens> Resolve(CodeLens request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/codeLens", async (message, token) =>
        {
            var request = message.Params!.Deserialize<CodeLensParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });

        server.AddRequestHandler("codeLens/resolve", async (message, token) =>
        {
            var request = message.Params!.Deserialize<CodeLens>(server.JsonSerializerOptions)!;
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
