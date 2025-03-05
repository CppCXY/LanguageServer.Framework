using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Markup;
using EmmyLua.LanguageServer.Framework.Protocol.Supplement;

namespace EmmyLua.LanguageServer.Framework.Protocol.Union;

[JsonConverter(typeof(MarkedStringsOrMarkupContentJsonConverter))]
public abstract record MarkedStringsOrMarkupContent
{
    public sealed record InternalMarkedStrings(List<MarkedString>? MarkedStrings) : MarkedStringsOrMarkupContent;

    public sealed record InternalMarkupContent(MarkupContent? Content) : MarkedStringsOrMarkupContent;
}

public class MarkedStringsOrMarkupContentJsonConverter : JsonConverter<MarkedStringsOrMarkupContent>
{
    public override MarkedStringsOrMarkupContent? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        var jsonNode = JsonNode.Parse(ref reader);
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            if (jsonNode?["language"] is not null && jsonNode.Deserialize<MarkedString>(options) is { } markedString)
                return new MarkedStringsOrMarkupContent.InternalMarkedStrings([markedString]);

            return new MarkedStringsOrMarkupContent.InternalMarkupContent(jsonNode.Deserialize<MarkupContent>(options));
        }

        if (reader.TokenType == JsonTokenType.StartArray)

            return new MarkedStringsOrMarkupContent.InternalMarkedStrings(jsonNode.Deserialize<List<MarkedString>>(options));


        if (reader.TokenType == JsonTokenType.String)
        {
            return new MarkedStringsOrMarkupContent.InternalMarkedStrings([
                new MarkedString() { Value = reader.GetString() ?? string.Empty }
            ]);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, MarkedStringsOrMarkupContent value, JsonSerializerOptions options)
    {
        if (value is MarkedStringsOrMarkupContent.InternalMarkedStrings markedStrings)
            writer.WriteRawValue(JsonSerializer.Serialize(markedStrings.MarkedStrings, options));
        if (value is MarkedStringsOrMarkupContent.InternalMarkupContent markedContent)
            writer.WriteRawValue(JsonSerializer.Serialize(markedContent.Content, options));
    }
}
