using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceDiagnostic;

/**
 * A full document diagnostic report for a workspace diagnostic result.
 *
 * @since 3.17.0
 */
[JsonConverter(typeof(WorkspaceDocumentDiagnosticReportJsonConverter))]
public class WorkspaceDocumentDiagnosticReport
{
    public object? Report { get; set; }

    public WorkspaceDocumentDiagnosticReport(WorkspaceFullDocumentDiagnosticReport report)
    {
        Report = report;
    }

    public WorkspaceDocumentDiagnosticReport(WorkspaceUnchangedDocumentDiagnosticReport report)
    {
        Report = report;
    }

    public static implicit operator WorkspaceDocumentDiagnosticReport(WorkspaceFullDocumentDiagnosticReport report)
    {
        return new WorkspaceDocumentDiagnosticReport(report);
    }

    public static implicit operator WorkspaceDocumentDiagnosticReport(WorkspaceUnchangedDocumentDiagnosticReport report)
    {
        return new WorkspaceDocumentDiagnosticReport(report);
    }
}

public class WorkspaceDocumentDiagnosticReportJsonConverter : JsonConverter<WorkspaceDocumentDiagnosticReport>
{
    public override WorkspaceDocumentDiagnosticReport Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, WorkspaceDocumentDiagnosticReport value, JsonSerializerOptions options)
    {
        if (value.Report is WorkspaceFullDocumentDiagnosticReport fullDocumentDiagnosticReport)
        {
            JsonSerializer.Serialize(writer, fullDocumentDiagnosticReport, options);
        }
        else if (value.Report is WorkspaceUnchangedDocumentDiagnosticReport unchangedDocumentDiagnosticReport)
        {
            JsonSerializer.Serialize(writer, unchangedDocumentDiagnosticReport, options);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
