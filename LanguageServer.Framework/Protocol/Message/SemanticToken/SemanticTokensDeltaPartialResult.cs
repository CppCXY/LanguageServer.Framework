using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokensDeltaPartialResult
{
    [JsonPropertyName("edits")] public List<SemanticTokensEdit> Edits { get; set; } = null!;
}
