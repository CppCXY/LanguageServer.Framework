using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

[JsonConverter(typeof(MarkedStringJsonConverter))]
public class MarkedString
{
    [JsonPropertyName("language")] public string? Language { get; init; }

    [JsonPropertyName("value")] public required string Value { get; init; }
}

public class MarkedStringJsonConverter : JsonConverter<MarkedString>
{
    public override MarkedString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return new MarkedString { Value = reader.GetString() ?? string.Empty };

            case JsonTokenType.StartObject:
                string? language = null;
                string? value = null;

                while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                {
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        var propName = reader.GetString();
                        reader.Read(); // Move to value

                        switch (propName)
                        {
                            case "language":
                                language = reader.GetString();
                                break;
                            case "value":
                                value = reader.GetString();
                                break;
                        }
                    }
                }

                return new MarkedString
                {
                    Language = language,
                    Value = value ?? string.Empty
                };

            default:
                return new MarkedString { Value = string.Empty };
        }
    }

    public override void Write(Utf8JsonWriter writer, MarkedString value, JsonSerializerOptions options)
    {
        if (string.IsNullOrWhiteSpace(value.Language))
        {
            writer.WriteStringValue(value.Value);
        }
        else
        {
            writer.WriteStartObject();
            writer.WriteString("language", value.Language);
            writer.WriteString("value", value.Value);
            writer.WriteEndObject();
        }
    }
}