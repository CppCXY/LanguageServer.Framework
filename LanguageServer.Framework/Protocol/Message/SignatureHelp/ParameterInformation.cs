using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

/**
 * Represents a parameter of a callable-signature. A parameter can
 * have a label and a doc-comment.
 */
public class ParameterInformation
{
    /**
     * The label of this parameter information.
     *
     * Either a string or an inclusive start and exclusive end offset within
     * its containing signature label (see SignatureInformation.label). The
     * offsets are based on a UTF-16 string representation, as `Position` and
     * `Range` do.
     *
     * To avoid ambiguities, a server should use the [start, end] offset value
     * instead of using a substring. Whether a client support this is
     * controlled via `labelOffsetSupport` client capability.
     *
     * *Note*: a label of type string should be a substring of its containing
     * signature label. Its intended use case is to highlight the parameter
     * label part in the `SignatureInformation.label`.
     */
    [JsonPropertyName("label")]
    public ParameterInformationLabel Label { get; set; } = null!;

    /**
     * The human-readable doc-comment of this parameter. Will be shown
     * in the UI but can be omitted.
     */
    [JsonPropertyName("documentation")]
    public StringOrMarkupContent? Documentation { get; set; }
}

[JsonConverter(typeof(ParameterInformationLabelJsonConverter))]
public class ParameterInformationLabel
{
    public string? Result1 { get; set; }

    public (uint, uint)? Result2 { get; set; }

    public ParameterInformationLabel(string result1)
    {
        Result1 = result1;
    }

    public ParameterInformationLabel((uint, uint) result2)
    {
        Result2 = result2;
    }

    public static implicit operator ParameterInformationLabel(string result1) => new(result1);

    public static implicit operator ParameterInformationLabel((uint, uint) result2) => new(result2);
}

public class ParameterInformationLabelJsonConverter : JsonConverter<ParameterInformationLabel>
{
    public override ParameterInformationLabel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            reader.Read();
            var start = reader.GetUInt32();
            reader.Read();
            var end = reader.GetUInt32();
            reader.Read();
            return new ParameterInformationLabel((start, end));
        }

        return new ParameterInformationLabel(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, ParameterInformationLabel value, JsonSerializerOptions options)
    {
        if (value.Result1 != null)
        {
            writer.WriteStringValue(value.Result1);
        }
        else if (value.Result2.HasValue)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Result2.Value.Item1);
            writer.WriteNumberValue(value.Result2.Value.Item2);
            writer.WriteEndArray();
        }
    }
}
