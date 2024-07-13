using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SemanticToken;

public class SemanticTokensRangeParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The text document.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The range the semantic tokens are requested for.
     */
    [JsonPropertyName("range")]
    public Range Range { get; set; }
}
