using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

/**
 * Parameters of the document diagnostic request.
 *
 * @since 3.17.0
 */
public class DocumentDiagnosticParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")] public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The text document.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The additional identifier  provided during registration.
     */
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /**
     * The result ID of a previous response, if provided.
     */
    [JsonPropertyName("previousResultId")]
    public string? PreviousResultId { get; set; }
}
