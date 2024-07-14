using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

/**
 * An inline completion item represents a text snippet that is proposed inline
 * to complete text that is being typed.
 *
 * @since 3.18.0
 */
public record InlineCompletionItem
{
    /**
     * The text to replace the range with. Must be set.
     * Is used both for the preview and the accept operation.
     */
    [JsonPropertyName("insertText"), JsonConverter(typeof(StringOrJsonConverter<StringValue>))]
    public StringOr<StringValue> InsertText { get; set; } = null!;

    /**
     * A text that is used to decide if this inline completion should be
     * shown. When `falsy`, the {@link InlineCompletionItem.insertText} is
     * used.
     *
     * An inline completion is shown if the text to replace is a prefix of the
     * filter text.
     */
    [JsonPropertyName("filterText")]
    public string? FilterText { get; set; }

    /**
     * The range to replace.
     * Must begin and end on the same line.
     *
     * Prefer replacements over insertions to provide a better experience when
     * the user deletes typed text.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * An optional {@link Command} that is executed *after* inserting this
     * completion.
     */
    [JsonPropertyName("command")]
    public Command? Command { get; set; }
}
