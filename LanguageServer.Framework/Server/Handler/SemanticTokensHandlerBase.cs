using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class SemanticTokensHandlerBase : IJsonHandler
{
    protected abstract Task<SemanticTokens?> Handle(SemanticTokensParams semanticTokensParams,
        CancellationToken cancellationToken);

    protected abstract Task<SemanticTokensDeltaResponse?> Handle(SemanticTokensDeltaParams semanticTokensDeltaParams,
        CancellationToken cancellationToken);

    protected abstract Task<SemanticTokens?> Handle(SemanticTokensRangeParams semanticTokensRangeParams,
        CancellationToken cancellationToken);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/semanticTokens/full", async (message, token) =>
        {
            var request = message.Params!.Deserialize<SemanticTokensParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });

        server.AddRequestHandler("textDocument/semanticTokens/full/delta", async (message, token) =>
        {
            var request = message.Params!.Deserialize<SemanticTokensDeltaParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });

        server.AddRequestHandler("textDocument/semanticTokens/range", async (message, token) =>
        {
            var request = message.Params!.Deserialize<SemanticTokensRangeParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
