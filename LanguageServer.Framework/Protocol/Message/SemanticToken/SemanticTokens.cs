using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokens
{
    /**
     * An optional result ID. If provided and clients support delta updating,
     * the client will include the result ID in the next semantic token request.
     * A server can then, instead of computing all semantic tokens again, simply
     * send a delta.
     */
    [JsonPropertyName("resultId")]
    public string? ResultId { get; set; }

    /**
     * The actual tokens.
     */
    [JsonPropertyName("data")]
    public List<uint> Data { get; set; } = null!;
}
