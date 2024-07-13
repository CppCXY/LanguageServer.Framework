using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

[JsonConverter(typeof(DocumentDiagnosticReportJsonConverter))]
public class DocumentDiagnosticReport
{
    public object Report { get; set; }

    public DocumentDiagnosticReport(RelatedFullDocumentDiagnosticReport report)
    {
        Report = report;
    }

    public DocumentDiagnosticReport(RelatedUnchangedDocumentDiagnosticReport report)
    {
        Report = report;
    }

    public static implicit operator DocumentDiagnosticReport(RelatedFullDocumentDiagnosticReport report)
    {
        return new DocumentDiagnosticReport(report);
    }

    public static implicit operator DocumentDiagnosticReport(RelatedUnchangedDocumentDiagnosticReport report)
    {
        return new DocumentDiagnosticReport(report);
    }
}

public class DocumentDiagnosticReportJsonConverter : JsonConverter<DocumentDiagnosticReport>
{
    public override DocumentDiagnosticReport Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, DocumentDiagnosticReport value, JsonSerializerOptions options)
    {
        if (value.Report is RelatedFullDocumentDiagnosticReport fullDocumentDiagnosticReport)
        {
            JsonSerializer.Serialize(writer, fullDocumentDiagnosticReport, options);
        }
        else if (value.Report is RelatedUnchangedDocumentDiagnosticReport unchangedDocumentDiagnosticReport)
        {
            JsonSerializer.Serialize(writer, unchangedDocumentDiagnosticReport, options);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
