using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceSymbol;

/**
 * The parameters of a Workspace Symbol Request.
 */
public class WorkspaceSymbolParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * A query string to filter symbols by. Clients may send an empty
     * string here to request all symbols.
     *
     * The `query`-parameter should be interpreted in a *relaxed way* as editors
     * will apply their own highlighting and scoring on the results. A good rule
     * of thumb is to match case-insensitive and to simply check that the
     * characters of *query* appear in their order in a candidate symbol.
     * Servers shouldn't use prefix, substring, or similar strict matching.
     */
    [JsonPropertyName("query")]
    public string Query { get; set; } = null!;
}
