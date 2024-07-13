using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;

/**
 * An unchanged document diagnostic report for a workspace diagnostic result.
 *
 * @since 3.17.0
 */
public class WorkspaceUnchangedDocumentDiagnosticReport : UnchangedDocumentDiagnosticReport
{
    /**
     * The URI for which diagnostic information is reported.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }

    /**
     * The version number for which the diagnostics are reported.
     * If the document is not marked as open, `null` can be provided.
     */
    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
