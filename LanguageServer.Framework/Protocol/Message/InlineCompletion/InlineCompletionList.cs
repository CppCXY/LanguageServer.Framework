using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

/**
 * Represents a collection of {@link InlineCompletionItem inline completion
 * items} to be presented in the editor.
 *
 * @since 3.18.0
 */
public class InlineCompletionList
{
    /**
     * The inline completion items.
     */
    [JsonPropertyName("items")]
    public List<InlineCompletionItem> Items { get; set; } = null!;
}
