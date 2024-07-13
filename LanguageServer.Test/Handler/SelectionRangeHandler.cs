using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SelectionRange;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class SelectionRangeHandler : SelectionRangeHandlerBase
{
    protected override Task<SelectionRangeResponse?> Handle(SelectionRangeParams request,
        CancellationToken cancellationToken)
    {
        Console.Error.WriteLine("SelectionRange");
        return Task.FromResult(new SelectionRangeResponse([
            new SelectionRange()
            {
                Range = new()
                {
                    Start = new Position(0, 0),
                    End = new Position(0, 0)
                },
                Parent = new SelectionRange()
                {
                    Range = new()
                    {
                        Start = new Position(0, 0),
                        End = new Position(0, 0)
                    }
                }
            }
        ]))!;
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.SelectionRangeProvider = true;
    }
}