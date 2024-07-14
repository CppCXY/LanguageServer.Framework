using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentHighlight;

/**
 * A document highlight is a range inside a text document which deserves
 * special attention. Usually a document highlight is visualized by changing
 * the background color of its range.
 *
 */
public class DocumentHighlight
{
    /**
     * The range this highlight applies to.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The highlight kind, default is DocumentHighlightKind.Text.
     */
    [JsonPropertyName("kind")]
    public DocumentHighlightKind Kind { get; set; }
}
