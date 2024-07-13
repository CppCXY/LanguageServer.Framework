using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentDiagnostic;

/**
 * The document diagnostic report kinds.
 *
 * @since 3.17.0
 */
[JsonConverter(typeof(DocumentDiagnosticReportKindJsonConverter))]
public readonly record struct DocumentDiagnosticReportKind(string Value)
{
    /**
     * A diagnostic report with a full
     * set of problems.
     */
    public static DocumentDiagnosticReportKind Full = new("full");

    /**
     * A report indicating that the last
     * returned report is still accurate.
     */
    public static DocumentDiagnosticReportKind Unchanged  = new("unchanged");

    public string Value { get; init; } = Value;
}

public class DocumentDiagnosticReportKindJsonConverter : JsonConverter<DocumentDiagnosticReportKind>
{
    public override DocumentDiagnosticReportKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new DocumentDiagnosticReportKind(reader.GetString() ?? string.Empty);
    }

    public override void Write(Utf8JsonWriter writer, DocumentDiagnosticReportKind value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value);
    }
}
