using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokensDelta
{
    [JsonPropertyName("resultId")]
    public string ResultId { get; set; } = null!;
    /**
     * The semantic token edits to transform a previous result into a new
     * result.
     */
    [JsonPropertyName("edits")] public List<SemanticTokensEdit> Edits { get; set; } = null!;
}
