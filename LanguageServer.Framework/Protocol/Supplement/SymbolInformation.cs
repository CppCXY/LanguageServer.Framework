using System.Collections.Generic;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

/**
 * Represents information about programming constructs like variables, classes,
 * interfaces etc.
 *
 * @deprecated use DocumentSymbol or WorkspaceSymbol instead.
 */
public record SymbolInformation
{
    /**
     * The name of this symbol.
     */
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /**
     * The kind of this symbol.
     */
    [JsonPropertyName("kind")]
    public required SymbolKind Kind { get; init; }

    /**
     * Tags for this symbol.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("tags")]
    public List<SymbolTag>? Tags { get; init; }

    /**
     * Indicates if this symbol is deprecated.
     *
     * @deprecated Use tags instead
     */
    [JsonPropertyName("deprecated")]
    public bool? Deprecated { get; init; }

    /**
     * The location of this symbol. The location's range is used by a tool
     * to reveal the location in the editor. If the symbol is selected in the
     * tool the range's start information is used to position the cursor. So
     * the range usually spans more then the actual symbol's name and does
     * normally include things like visibility modifiers.
     *
     * The range doesn't have to denote a node range in the sense of an abstract
     * syntax tree. It can therefore not be used to re-construct a hierarchy of
     * the symbols.
     */
    [JsonPropertyName("location")]
    public required Location Location { get; init; }

    /**
     * The name of the symbol containing this symbol. This information is for
     * user interface purposes (e.g. to render a qualifier in the user interface
     * if necessary). It can't be used to re-infer a hierarchy for the document
     * symbols.
     */
    [JsonPropertyName("containerName")]
    public string? ContainerName { get; init; }
}