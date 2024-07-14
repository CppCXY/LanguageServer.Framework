using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

/**
 * Additional details for a completion item label.
 *
 * @since 3.17.0
 */
public record CompletionItemLabelDetails
{
    /**
     * An optional string which is rendered less prominently directly after
     * {@link CompletionItem.label label}, without any spacing. Should be
     * used for function signatures or type annotations.
     */
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /**
     * An optional string which is rendered less prominently after
     * {@link CompletionItemLabelDetails.detail}. Should be used for fully qualified
     * names or file paths.
     */
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
