using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;

/**
 * Inlay hint information.
 *
 * @since 3.17.0
 */
public record InlayHint
{
    /**
     * The position of this hint.
     *
     * If multiple hints have the same position, they will be shown in the order
     * they appear in the response.
     */
    [JsonPropertyName("position")]
    public Position Position { get; set; }

    /**
     * The label of this hint. A human readable string or an array of
     * InlayHintLabelPart label parts.
     *
     * *Note* that neither the string nor the label part can be empty.
     */
    [JsonPropertyName("label"), JsonConverter(typeof(StringOrJsonConverter<List<InlayHintLabelPart>>))]
    public StringOr<List<InlayHintLabelPart>> Label { get; set; } = null!;

    /**
     * The kind of this hint. Can be omitted in which case the client
     * should fall back to a reasonable default.
     */
    [JsonPropertyName("kind")]
    public InlayHintKind? Kind { get; set; }

    /**
     * Optional text edits that are performed when accepting this inlay hint.
     *
     * *Note* that edits are expected to change the document so that the inlay
     * hint (or its nearest variant) is now part of the document and the inlay
     * hint itself is now obsolete.
     *
     * Depending on the client capability `inlayHint.resolveSupport`,
     * clients might resolve this property late using the resolve request.
     */
    [JsonPropertyName("textEdits")]
    public List<TextEdit>? TextEdits { get; set; }

    /**
     * The tooltip text when you hover over this item.
     *
     * Depending on the client capability `inlayHint.resolveSupport` clients
     * might resolve this property late using the resolve request.
     */
    [JsonPropertyName("tooltip")]
    public StringOrMarkupContent? Tooltip { get; set; }

    /**
     * Render padding before the hint.
     *
     * Note: Padding should use the editor's background color, not the
     * background color of the hint itself. That means padding can be used
     * to visually align/separate an inlay hint.
     */
    [JsonPropertyName("paddingLeft")]
    public bool? PaddingLeft { get; set; }

    /**
     * Render padding after the hint.
     *
     * Note: Padding should use the editor's background color, not the
     * background color of the hint itself. That means padding can be used
     * to visually align/separate an inlay hint.
     */
    [JsonPropertyName("paddingRight")]
    public bool? PaddingRight { get; set; }

    /**
     * A data entry field that is preserved on an inlay hint between
     * a `textDocument/inlayHint` and an `inlayHint/resolve` request.
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}
