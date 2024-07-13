using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

/**
 * A partial result for a document diagnostic report.
 *
 * @since 3.17.0
 */
public class DocumentDiagnosticReportPartialResult
{
    [JsonPropertyName("relatedDocuments")]
    public Dictionary<DocumentUri, FullOrUnchangeDocumentDiagnosticReport> RelatedDocuments { get; set; } = null!;
}
