using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;

/**
 * A workspace diagnostic report.
 *
 * @since 3.17.0
 */
public class WorkspaceDiagnosticReport
{
    [JsonPropertyName("items")]
    public List<WorkspaceDocumentDiagnosticReport> Items { get; set; } = null!;
}
