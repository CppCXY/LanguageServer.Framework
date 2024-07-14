using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;

/**
 * Represents programming constructs like variables, classes, interfaces etc.
 * that appear in a document. Document symbols can be hierarchical and they
 * have two ranges: one that encloses their definition and one that points to
 * their most interesting range, e.g. the range of an identifier.
 */
public record DocumentSymbol
{
    /**
     * The name of this symbol. Will be displayed in the user interface and
     * therefore must not be an empty string or a string only consisting of
     * white spaces.
     */
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /**
     * More detail for this symbol, e.g the signature of a function.
     */
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /**
     * The kind of this symbol.
     */
    [JsonPropertyName("kind")]
    public SymbolKind Kind { get; set; }

    // @deprecated Use tags instead
    // deprecated?: boolean;

    /**
     * Tags for this document symbol.
     */
    [JsonPropertyName("tags")]
    public List<SymbolTag>? Tags { get; set; }

    /**
     * The range enclosing this symbol not including leading/trailing whitespace
     * but everything else like comments. This information is typically used to
     * determine if the the clients cursor is inside the symbol to reveal in the
     * symbol in the UI.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The range that should be selected and revealed when this symbol is being
     * picked, e.g. the name of a function. Must be contained by the `range`.
     */
    [JsonPropertyName("selectionRange")]
    public DocumentRange SelectionRange { get; set; }

    /**
     * Children of this symbol, e.g. properties of a class.
     */
    [JsonPropertyName("children")]
    public List<DocumentSymbol>? Children { get; set; }
}
