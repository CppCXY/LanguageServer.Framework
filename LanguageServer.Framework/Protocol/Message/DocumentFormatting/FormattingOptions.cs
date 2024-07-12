using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentFormatting;

/**
 * Value-object describing what options formatting should use.
 */
public class FormattingOptions
{
    /**
     * Size of a tab in spaces.
     */
    [JsonPropertyName("tabSize")]
    public uint TabSize { get; set; }

    /**
     * Prefer spaces over tabs.
     */
    [JsonPropertyName("insertSpaces")]
    public bool InsertSpaces { get; set; }

    /**
     * Trim trailing whitespace on a line.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("trimTrailingWhitespace")]
    public bool TrimTrailingWhitespace { get; set; }

    /**
     * Insert a newline character at the end of the file if one does not exist.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("insertFinalNewline")]
    public bool InsertFinalNewline { get; set; }

    /**
     * Trim all newlines after the final newline at the end of the file.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("trimFinalNewlines")]
    public bool TrimFinalNewlines { get; set; }

    // TODO
}
