using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Markup;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Hover;

/**
 * The result of a hover request.
 */
public class HoverResponse
{
    /* the real type is MarkedString | MarkedString[] | MarkupContent;
     * but MarkedString is marked as deprecated, so we use MarkupContent here
     */
    /**
     * The hover's content.
     */
    [JsonPropertyName("contents")]
    public MarkupContent Contents { get; set; } = null!;

    /**
     * An optional range is a range inside a text document
     * that is used to visualize a hover, e.g. by changing the background color.
     */
    [JsonPropertyName("range")]
    public DocumentRange? Range { get; set; }
}
