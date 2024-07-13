using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

public class RelatedUnchangedDocumentDiagnosticReport : UnchangedDocumentDiagnosticReport
{
    /**
     * Diagnostics of related documents. This information is useful
     * in programming languages where code in a file A can generate
     * diagnostics in a file B which A depends on. An example of
     * such a language is C/C++, where macro definitions in a file
     * a.cpp can result in errors in a header file b.hpp.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("relatedDocuments")]
    public Dictionary<DocumentUri, FullOrUnchangeDocumentDiagnosticReport> RelatedDocuments { get; set; } = null!;
}
