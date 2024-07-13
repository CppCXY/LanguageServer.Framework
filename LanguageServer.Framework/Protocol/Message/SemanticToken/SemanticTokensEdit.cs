using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokensEdit
{
    /**
     * The start offset of the edit.
     */
    [JsonPropertyName("start")]
    public uint Start { get; set; }

    /**
     * The number of elements to remove.
     */
    [JsonPropertyName("deleteCount")]
    public uint DeleteCount { get; set; }

    /**
     * The elements to insert.
     */
    [JsonPropertyName("data")]
    public List<uint>? Data { get; set; }
}
