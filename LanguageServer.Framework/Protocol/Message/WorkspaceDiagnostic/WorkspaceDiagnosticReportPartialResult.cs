using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;

/**
 * A partial result for a workspace diagnostic report.
 *
 * @since 3.17.0
 */
public class WorkspaceDiagnosticReportPartialResult
{
    [JsonPropertyName("items")]
    public List<WorkspaceDocumentDiagnosticReport> Items { get; set; } = null!;
}
