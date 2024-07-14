using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

// use anthor name DocumentRange instead of Range
[method: JsonConstructor]
public record struct DocumentRange(Position Start, Position End)
{
    /**
     * The range's start position.
     */
    [JsonPropertyName("start")]
    public Position Start { get; init; } = Start;

    /**
     * The range's end position.
     */
    [JsonPropertyName("end")]
    public Position End { get; init; } = End;

    public DocumentRange() : this(default, default)
    {
    }

    public static DocumentRange From(Position start, Position end) => new DocumentRange(start, end);
    public static DocumentRange From((Position start, Position end) tuple) => new DocumentRange(tuple.start, tuple.end);

    public static implicit operator DocumentRange((Position start, Position end) tuple) => From(tuple);

    public static implicit operator (Position start, Position end)(DocumentRange range) => (range.Start, range.End);
}
