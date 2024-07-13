using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceSymbol;

/**
 * A special workspace symbol that supports locations without a range.
 *
 * @since 3.17.0
 */
public class WorkspaceSymbol
{
    /**
     * The name of this symbol.
     */
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /**
     * The kind of this symbol.
     */
    [JsonPropertyName("kind")]
    public SymbolKind Kind { get; set; }

    /**
     * Tags for this completion item.
     */
    [JsonPropertyName("tags")]
    public List<SymbolTag>? Tags { get; set; }

    /**
     * The name of the symbol containing this symbol. This information is for
     * user interface purposes (e.g. to render a qualifier in the user interface
     * if necessary). It can't be used to re-infer a hierarchy for the document
     * symbols.
     */
    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    /**
     * The location of this symbol. Whether a server is allowed to
     * return a location without a range depends on the client
     * capability `workspace.symbol.resolveSupport`.
     *
     * See also `SymbolInformation.location`.
     */
    [JsonPropertyName("location")]
    public Location? Location { get; set; }

    /**
     * A data entry field that is preserved on a workspace symbol between a
     * workspace symbol request and a workspace symbol resolve request.
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}
