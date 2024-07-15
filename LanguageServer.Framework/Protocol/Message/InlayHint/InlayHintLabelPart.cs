using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;

/**
 * An inlay hint label part allows for interactive and composite labels
 * of inlay hints.
 *
 * @since 3.17.0
 */
public class InlayHintLabelPart
{
    /**
     * The value of this label part.
     */
    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;

    /**
     * The tooltip text when you hover over this label part. Depending on
     * the client capability `inlayHint.resolveSupport`, clients might resolve
     * this property late using the resolve request.
     */
    [JsonPropertyName("tooltip")]
    public StringOrMarkupContent? Tooltip { get; set; }

    /**
     * An optional source code location that represents this
     * label part.
     *
     * The editor will use this location for the hover and for code navigation
     * features: This part will become a clickable link that resolves to the
     * definition of the symbol at the given location (not necessarily the
     * location itself), it shows the hover that shows at the given location,
     * and it shows a context menu with further code navigation commands.
     *
     * Depending on the client capability `inlayHint.resolveSupport` clients
     * might resolve this property late using the resolve request.
     */
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

    /**
     * An optional command for this label part.
     *
     * Depending on the client capability `inlayHint.resolveSupport`, clients
     * might resolve this property late using the resolve request.
     */
    [JsonPropertyName("command")]
    public Command? Command { get; set; }
}
