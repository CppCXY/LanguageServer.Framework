using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class SignatureHelpHandlerBase : IJsonHandler
{
    protected abstract Task<SignatureHelp> Handle(SignatureHelpParams request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/signatureHelp", async (message, token) =>
        {
            var request = message.Params!.Deserialize<SignatureHelpParams>(server.JsonSerializerOptions)!;
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
