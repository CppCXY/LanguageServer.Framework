using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class InlineValueHandler : InlineValueHandlerBase
{
    protected override Task<InlineValueResponse> Handle(InlineValueParams inlineValueParams,
        CancellationToken cancellationToken)
    {
        Console.Error.WriteLine("InlineValueHandler.Handle");
        return Task.FromResult(new InlineValueResponse([]));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.InlineValueProvider = true;
    }
}