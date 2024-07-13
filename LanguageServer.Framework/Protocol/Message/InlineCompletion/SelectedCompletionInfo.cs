using System.Text.Json.Serialization;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

/**
 * Describes the currently selected completion item.
 *
 * @since 3.18.0
 */
public class SelectedCompletionInfo
{
    /**
     * The range that will be replaced if this completion item is accepted.
     */
    [JsonPropertyName("range")]
    public Range Range { get; set; }

    /**
     * The text the range will be replaced with if this completion is
     * accepted.
     */
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}
