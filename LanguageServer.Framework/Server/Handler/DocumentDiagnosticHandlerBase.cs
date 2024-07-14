using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class DocumentDiagnosticHandlerBase : IJsonHandler
{
    protected abstract Task<DocumentDiagnosticReport> Handle(DocumentDiagnosticParams request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/diagnostic", async (message, token) =>
        {
            var request = message.Params!.Deserialize<DocumentDiagnosticParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
