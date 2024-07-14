using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

public record LocationLink(
    DocumentRange? OriginSelectionRange,
    DocumentUri TargetUri,
    DocumentRange TargetRange,
    DocumentRange TargetSelectionRange)
{
    /**
     * Span of the origin of this link.
     *
     * Used as the underlined span for mouse interaction. Defaults to the word
     * range at the mouse position.
     */
    [JsonPropertyName("originSelectionRange")]
    public DocumentRange? OriginSelectionRange { get; } = OriginSelectionRange;

    /**
     * The target resource identifier of this link.
     */
    [JsonPropertyName("targetUri")]
    public DocumentUri TargetUri { get; } = TargetUri;

    /**
     * The full target range of this link. If the target for example is a symbol then target range is the
     * range enclosing this symbol not including leading/trailing whitespace but everything else
     * like comments. This information is typically used to highlight the range in the editor.
     */
    [JsonPropertyName("targetRange")]
    public DocumentRange TargetRange { get; } = TargetRange;

    /**
     * The range that should be selected and revealed when this link is being followed, e.g the name of a function.
     * Must be contained by the the `targetRange`. See also `DocumentSymbol#range`
     */
    [JsonPropertyName("targetSelectionRange")]
    public DocumentRange TargetSelectionRange { get; } = TargetSelectionRange;
}