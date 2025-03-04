using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public class Moniker
{
    /// <summary>
    /// The scheme of the moniker. For example tsc or .Net
    /// </summary>
    [JsonPropertyName("scheme")]
    public required string Scheme { get; init; }

    /// <summary>
    /// The identifier of the moniker. The value is opaque in LSIF however
    /// schema owners are allowed to define the structure if they want.
    /// </summary>
    [JsonPropertyName("identifier")]
    public required string Identifier { get; init; }

    /// <summary>
    /// The scope in which the moniker is unique
    /// </summary>
    [JsonPropertyName("unique")]
    public required UniquenessLevel Unique { get; init; }

    /// <summary>
    /// The moniker kind if known.
    /// </summary>
    [JsonPropertyName("kind")]
    public MonikerKind Kind { get; init; }
}