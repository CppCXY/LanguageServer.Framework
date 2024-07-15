using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class InlayHintHandler : InlayHintHandlerBase
{
    protected override Task<InlayHintResponse?> Handle(InlayHintParams request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new InlayHintResponse([
            new InlayHint()
            {
                Position = new(0, 2),
                PaddingRight = true,
                Label = new([
                    new InlayHintLabelPart()
                    {
                        Value = "hello world",
                        Location = new Location(request.TextDocument.Uri, new())
                    }
                ])
            }
        ]))!;
    }

    protected override Task<InlayHint> Resolve(InlayHint request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request);
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.InlayHintProvider = new InlayHintsOptions()
        {
            ResolveProvider = true
        };
    }
}