using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.TypeHierarchy;

public class TypeHierarchyItem
{
    /**
     * The name of this item.
     */
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /**
     * The kind of this item.
     */
    [JsonPropertyName("kind")]
    public SymbolKind Kind { get; set; }

    /**
     * Tags for this item.
     */
    [JsonPropertyName("tags")]
    public List<SymbolTag> Tags { get; set; } = null!;

    /**
     * More detail for this item, e.g. the signature of a function.
     */
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /**
     * The resource identifier of this item.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }

    /**
     * The range enclosing this symbol not including leading/trailing whitespace but everything else, e.g. comments and code.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The range that should be selected and revealed when this symbol is being
     * picked, e.g. the name of a function. Must be contained by the
     * [`range`](#TypeHierarchyItem.range).
     */
    [JsonPropertyName("selectionRange")]
    public DocumentRange SelectionRange { get; set; }

    /**
     * A data entry field that is preserved between a type hierarchy prepare and
     * supertypes or subtypes requests. It could also be used to identify the
     * type hierarchy in the server, helping improve the performance on
     * resolving supertypes and subtypes.
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}
