using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokensPartialResult
{
    [JsonPropertyName("data")]
    public List<uint> Data { get; set; } = null!;
}
