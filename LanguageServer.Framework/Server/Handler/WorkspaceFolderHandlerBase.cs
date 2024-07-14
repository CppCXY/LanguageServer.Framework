using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFolders;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class WorkspaceFolderHandlerBase : IJsonHandler
{
    protected abstract Task Handle(DidChangeWorkspaceFoldersParams request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddNotificationHandler("workspace/didChangeWorkspaceFolders", (message, token) =>
        {
            var request = message.Params!.Deserialize<DidChangeWorkspaceFoldersParams>(server.JsonSerializerOptions)!;
            return Handle(request, token);
        });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
