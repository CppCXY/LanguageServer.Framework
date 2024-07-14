using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Rename;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class RenameHandler : RenameHandlerBase
{
    protected override Task<WorkspaceEdit?> Handle(RenameParams request, CancellationToken token)
    {
        Console.Error.WriteLine("RenameHandler.Handle");
        var newName = request.NewName;
        var changes = new Dictionary<DocumentUri, List<TextEdit>>();
        changes[request.TextDocument.Uri] =
        [
            new TextEdit()
            {
                Range = new DocumentRange(request.Position,
                    request.Position with { Character = request.Position.Character + 1 }),
                NewText = newName
            }
        ];
        return Task.FromResult(changes.Count > 0 ? new WorkspaceEdit { Changes = changes } : null);
    }

    protected override Task<PrepareRenameResponse> Handle(PrepareRenameParams request, CancellationToken token)
    {
        Console.Error.WriteLine("RenameHandler.PrepareRename");
        return Task.FromResult(new PrepareRenameResponse(new DocumentRange(request.Position,
            request.Position with { Character = request.Position.Character + 1 })));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.RenameProvider = new RenameOptions
        {
            PrepareProvider = true
        };
    }
}