using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

[JsonConverter(typeof(FullOrUnchangeDocumentDiagnosticReportJsonConverter))]
public class FullOrUnchangeDocumentDiagnosticReport
{
    public object Report { get; set; }

    public FullOrUnchangeDocumentDiagnosticReport(FullDocumentDiagnosticReport report)
    {
        Report = report;
    }

    public FullOrUnchangeDocumentDiagnosticReport(UnchangedDocumentDiagnosticReport report)
    {
        Report = report;
    }

    public static implicit operator FullOrUnchangeDocumentDiagnosticReport(FullDocumentDiagnosticReport report)
    {
        return new FullOrUnchangeDocumentDiagnosticReport(report);
    }

    public static implicit operator FullOrUnchangeDocumentDiagnosticReport(UnchangedDocumentDiagnosticReport report)
    {
        return new FullOrUnchangeDocumentDiagnosticReport(report);
    }
}

public class FullOrUnchangeDocumentDiagnosticReportJsonConverter : JsonConverter<FullOrUnchangeDocumentDiagnosticReport>
{
    public override FullOrUnchangeDocumentDiagnosticReport Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, FullOrUnchangeDocumentDiagnosticReport value, JsonSerializerOptions options)
    {
        if (value.Report is FullDocumentDiagnosticReport fullDocumentDiagnosticReport)
        {
            JsonSerializer.Serialize(writer, fullDocumentDiagnosticReport, options);
        }
        else if (value.Report is UnchangedDocumentDiagnosticReport unchangedDocumentDiagnosticReport)
        {
            JsonSerializer.Serialize(writer, unchangedDocumentDiagnosticReport, options);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
