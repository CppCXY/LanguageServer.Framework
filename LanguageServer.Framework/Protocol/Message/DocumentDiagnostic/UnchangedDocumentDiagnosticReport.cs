using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

/**
 * A diagnostic report indicating that the last returned
 * report is still accurate.
 *
 * @since 3.17.0
 */
public class UnchangedDocumentDiagnosticReport
{
    /**
     * A document diagnostic report indicating
     * no changes to the last result. A server can
     * only return `unchanged` if result IDs are
     * provided.
     */
    [JsonPropertyName("kind")]
    public DocumentDiagnosticReportKind Kind { get; } = DocumentDiagnosticReportKind.Unchanged;

    /**
     * A result ID which will be sent on the next
     * diagnostic request for the same document.
     */
    [JsonPropertyName("resultId")]
    public string? ResultId { get; set; }
}
