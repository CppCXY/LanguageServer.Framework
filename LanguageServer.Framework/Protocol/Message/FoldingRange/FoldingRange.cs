using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.FoldingRange;

/**
 * Represents a folding range. To be valid, start and end line must be bigger
 * than zero and smaller than the number of lines in the document. Clients
 * are free to ignore invalid ranges.
 */
public record FoldingRange
{
    /**
     * The zero-based start line of the range to fold. The folded area starts
     * after the line's last character. To be valid, the end must be zero or
     * larger and smaller than the number of lines in the document.
     */
    [JsonPropertyName("startLine")]
    public uint StartLine { get; set; }

    /**
     * The zero-based start character of the start line. If not defined, the
     * length is considered to be the line length.
     */
    [JsonPropertyName("startCharacter")]
    public uint? StartCharacter { get; set; }

    /**
     * The zero-based end line of the range to fold. The folded area ends with
     * the line's last character. To be valid, the end must be zero or larger
     * and smaller than the number of lines in the document.
     */
    [JsonPropertyName("endLine")]
    public uint EndLine { get; set; }

    /**
     * The zero-based end character of the end line. If not defined, the end
     * character is the line length.
     */
    [JsonPropertyName("endCharacter")]
    public uint? EndCharacter { get; set; }

    /**
     * Describes the kind of the folding range such as `comment` or `region`.
     * The kind is used to categorize folding ranges and used by commands like
     * 'Fold all comments'. See [FoldingRangeKind](#FoldingRangeKind) for an
     * enumeration of standardized kinds.
     */
    [JsonPropertyName("kind")]
    public FoldingRangeKind? Kind { get; set; }

    /**
     * The text that the client should show when the specified range is
     * collapsed. If not defined or not supported by the client, a default
     * will be chosen by the client.
     *
     * @since 3.17.0 - proposed
     */
    [JsonPropertyName("collapsedText")]
    public string? CollapsedText { get; set; }
}
