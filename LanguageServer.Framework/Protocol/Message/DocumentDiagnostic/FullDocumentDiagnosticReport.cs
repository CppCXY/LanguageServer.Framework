using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

/**
 * A diagnostic report with a full set of problems.
 *
 * @since 3.17.0
 */
public class FullDocumentDiagnosticReport
{
    /**
     * A full document diagnostic report.
     */
    [JsonPropertyName("kind")]
    public DocumentDiagnosticReportKind Kind { get; } = DocumentDiagnosticReportKind.Full;

    /**
     * An optional result ID. If provided, it will
     * be sent on the next diagnostic request for the
     * same document.
     */
    [JsonPropertyName("resultId")]
    public string? ResultId { get; set; }

    /**
     * The actual diagnostics.
     */
    [JsonPropertyName("diagnostics")]
    public List<Diagnostic> Diagnostics { get; set; } = null!;
}
