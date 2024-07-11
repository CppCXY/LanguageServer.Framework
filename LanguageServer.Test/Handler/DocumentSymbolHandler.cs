using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;
using EmmyLua.LanguageServer.Framework.Server.Handler;


namespace EmmyLua.LanguageServer.Framework.Handler;

public class DocumentSymbolHandler : DocumentSymbolHandlerBase
{
    protected override Task<DocumentSymbolResponse> Handle(DocumentSymbolParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentSymbol");
        return Task.FromResult(new DocumentSymbolResponse([
            new DocumentSymbol()
            {
                Name = "DocumentSymbol",
                Kind = SymbolKind.Class,
                Range = new()
                {
                    Start = new Position(0, 0),
                    End = new Position(0, 1)
                },
                SelectionRange = new()
                {
                    Start = new Position(0, 0),
                    End = new Position(0, 1)
                }
            }
        ]));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.DocumentSymbolProvider = true;
    }
}