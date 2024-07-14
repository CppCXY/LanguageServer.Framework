using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentLink;

/**
 * A document link is a range in a text document that links to an internal or
 * external resource, like another text document or a web site.
 */
public class DocumentLink
{
    /**
     * The range this link applies to.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The uri this link points to. If missing a resolve request is sent later.
     */
    [JsonPropertyName("target")]
    public DocumentUri? Target { get; set; }

    /**
     * The tooltip text when you hover over this link.
     *
     * If a tooltip is provided, it will be displayed in a string that includes
     * instructions on how to trigger the link, such as `{0} (ctrl + click)`.
     * The specific instructions vary depending on OS, user settings, and
     * localization.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("tooltip")]
    public string? Tooltip { get; set; }

    /**
     * A data entry field that is preserved on a document link between a
     * document link and a document link resolve request.
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}
