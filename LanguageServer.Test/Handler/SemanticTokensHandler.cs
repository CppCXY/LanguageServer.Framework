using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Common;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class SemanticTokensHandler : SemanticTokensHandlerBase
{
    private List<string> TokenTypes { get; init; } =
    [
        SemanticTokenTypes.Comment
    ];

    private List<string> TokenModifiers { get; init; } =
    [
        SemanticTokenModifiers.Documentation
    ];

    protected override Task<SemanticTokens?> Handle(SemanticTokensParams semanticTokensParams,
        CancellationToken cancellationToken)
    {
        var semanticTokenBuilder = new SemanticTokensBuilder(TokenTypes, TokenModifiers);
        semanticTokenBuilder.Push(new Position(0, 2), 2, SemanticTokenTypes.Comment,
            SemanticTokenModifiers.Documentation);
        semanticTokenBuilder.Push(new Position(1, 0), 3, SemanticTokenTypes.Comment,
            SemanticTokenModifiers.Documentation);

        return Task.FromResult(new SemanticTokens()
        {
            Data = semanticTokenBuilder.Build()
        })!;
    }

    protected override Task<SemanticTokensDeltaResponse?> Handle(SemanticTokensDeltaParams semanticTokensDeltaParams,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected override Task<SemanticTokens?> Handle(SemanticTokensRangeParams semanticTokensRangeParams,
        CancellationToken cancellationToken)
    {
        var semanticTokenBuilder = new SemanticTokensBuilder(TokenTypes, TokenModifiers);
        semanticTokenBuilder.Push(new Position(0, 2), 2, SemanticTokenTypes.Comment,
            SemanticTokenModifiers.Documentation);

        return Task.FromResult(new SemanticTokens()
        {
            Data = semanticTokenBuilder.Build()
        })!;
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.SemanticTokensProvider = new SemanticTokensOptions()
        {
            Legend = new SemanticTokensLegend()
            {
                TokenTypes = TokenTypes,
                TokenModifiers = TokenModifiers,
            },
            Full = true,
            Range = true,
        };
    }
}