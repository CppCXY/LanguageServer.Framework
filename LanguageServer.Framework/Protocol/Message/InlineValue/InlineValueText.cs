using System.Text.Json.Serialization;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

/**
 * Provide inline value as text.
 *
 * @since 3.17.0
 */
public class InlineValueText
{
    /**
     * The document range for which the inline value applies.
     */
    [JsonPropertyName("range")]
    public Range Range { get; set; }

    /**
     * The text of the inline value.
     */
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;
}
