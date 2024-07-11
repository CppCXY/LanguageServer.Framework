using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

// ReSharper disable once InconsistentNaming
[JsonConverter(typeof(LSPAnyJsonConverter))]
public class LSPAny
{
    public object Value { get; }

    public LSPAny(JsonDocument jsonDocument)
    {
        Value = jsonDocument;
    }

    public LSPAny(string value)
    {
        Value = value;
    }

    public LSPAny(int value)
    {
        Value = value;
    }

    public LSPAny(bool value)
    {
        Value = value;
    }

    public static implicit operator LSPAny(string value) => new LSPAny(value);
    public static implicit operator LSPAny(int value) => new LSPAny(value);
    public static implicit operator LSPAny(bool value) => new LSPAny(value);
    public static implicit operator LSPAny(JsonDocument value) => new LSPAny(value);
}

// ReSharper disable once InconsistentNaming
public class LSPAnyJsonConverter : JsonConverter<LSPAny>
{
    public override LSPAny Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new LSPAny(reader.GetString()!);
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            return new LSPAny(reader.GetInt32());
        }

        if (reader.TokenType is JsonTokenType.True or JsonTokenType.False)
        {
            return new LSPAny(reader.GetBoolean());
        }

        var jsonDocument = JsonDocument.ParseValue(ref reader);
        return new LSPAny(jsonDocument);
    }

    public override void Write(Utf8JsonWriter writer, LSPAny value, JsonSerializerOptions options)
    {
        switch (value.Value)
        {
            case string stringValue:
                writer.WriteStringValue(stringValue);
                break;
            case int intValue:
                writer.WriteNumberValue(intValue);
                break;
            case bool boolValue:
                writer.WriteBooleanValue(boolValue);
                break;
            case JsonDocument jsonDocument:
                jsonDocument.WriteTo(writer);
                break;
            default:
                throw new JsonException();
        }
    }
}
