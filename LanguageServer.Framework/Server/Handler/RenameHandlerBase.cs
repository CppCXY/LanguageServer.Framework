using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Rename;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class RenameHandlerBase : IJsonHandler
{
    protected abstract Task<WorkspaceEdit?> Handle(RenameParams request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities);
}
