using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

[method: JsonConstructor]
public readonly record struct Position(int Line, int Character)
{
    /**
     * Line position in a document (zero-based).
     */
    [JsonPropertyName("line")]
    public int Line { get; init; } = Line;

    /**
     * Character offset on a line in a document (zero-based). The meaning of this
     * offset is determined by the negotiated `PositionEncodingKind`.
     *
     * If the character value is greater than the line length it defaults back
     * to the line length.
     */
    [JsonPropertyName("character")]
    public int Character { get; init; } = Character;

    public Position() : this(0, 0)
    {
    }
}
