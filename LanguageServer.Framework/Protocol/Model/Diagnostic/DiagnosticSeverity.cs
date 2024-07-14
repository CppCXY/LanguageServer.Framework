using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;

[JsonConverter(typeof(DiagnosticSeverityJsonConverter))]
public enum DiagnosticSeverity
{
    /**
     * Reports an error.
     */
    Error = 1,

    /**
     * Reports a warning.
     */
    Warning = 2,

    /**
     * Reports an information.
     */
    Information = 3,

    /**
     * Reports a hint.
     */
    Hint = 4

}

public class DiagnosticSeverityJsonConverter : JsonConverter<DiagnosticSeverity>
{
    public override DiagnosticSeverity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return (DiagnosticSeverity)reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, DiagnosticSeverity value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
