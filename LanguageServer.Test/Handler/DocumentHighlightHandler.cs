using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentHighlight;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;


namespace EmmyLua.LanguageServer.Framework.Handler;

public class DocumentHighlightHandler : DocumentHighlightHandlerBase
{
    protected override Task<DocumentHighlightResponse> Handle(DocumentHighlightParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentHighlight");
        return Task.FromResult(new DocumentHighlightResponse([
            new DocumentHighlight()
            {
                Range = new ()
                {
                    Start = request.Position,
                    End = request.Position with { Character = request.Position.Character + 1 }
                },
                Kind = DocumentHighlightKind.Text
            }
        ]));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.DocumentHighlightProvider = true;
    }
}