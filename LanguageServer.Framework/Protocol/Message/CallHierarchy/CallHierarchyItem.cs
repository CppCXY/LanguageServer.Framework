using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CallHierarchy;

public record CallHierarchyItem
{
    /**
     * The name of this item.
     */
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /**
     * The kind of this item.
     */
    [JsonPropertyName("kind")]
    public SymbolKind Kind { get; set; }

    /**
     * Tags for this item.
     */
    [JsonPropertyName("tags")]
    public List<SymbolTag>? Tags { get; set; }

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
     * The range that should be selected and revealed when this symbol is being picked, e.g. the name of a function.
     * Must be contained by the `range`.
     */
    [JsonPropertyName("selectionRange")]
    public DocumentRange SelectionRange { get; set; }

    /**
     * A data entry field that is preserved between a call hierarchy prepare and a call hierarchy incoming calls or outgoing calls request.
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}
