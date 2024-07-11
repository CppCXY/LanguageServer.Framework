using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeLens;

public class CodeLensParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The document to request code lens for.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;
}
