using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.FoldingRange;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class FoldingRangeHandler : FoldingRangeHandlerBase
{
    protected override Task<FoldingRangeResponse> Handle(FoldingRangeParams request, CancellationToken token)
    {
        Console.Error.WriteLine("FoldingRangeHandler.Handle");
        return Task.FromResult(new FoldingRangeResponse([
            new FoldingRange()
            {
                StartLine = 1,
                StartCharacter = 0,
                EndLine = 3,
                EndCharacter = 0,
                Kind = FoldingRangeKind.Comment,
                CollapsedText = "collapsed text"
            }
        ]));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.FoldingRangeProvider = new FoldingRangeOptions();
    }
}