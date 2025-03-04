using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Markup;
using WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

namespace EmmyLua.LanguageServer.Framework.Protocol.Union;

[JsonConverter(typeof(MarkedStringsOrMarkupContentJsonConverter))]
public record MarkedStringsOrMarkupContent
{
    public List<MarkedString>? MarkedStrings { get; init; }
    public MarkupContent? MarkupContent { get; init; }
}

public class MarkedStringsOrMarkupContentJsonConverter : JsonConverter<MarkedStringsOrMarkupContent>
{
    public override MarkedStringsOrMarkupContent? Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            var jsonObj = JsonObject.Parse(ref reader);
            if (jsonObj?["language"] is not null)
            {
                var obj = jsonObj.Deserialize<MarkedString>(options);
                return new()
                {
                    MarkedStrings = obj is not null ? [obj] : null
                };
            }

            return new()
            {
                MarkupContent = jsonObj.Deserialize<MarkupContent>(options)
            };
        }

        if (reader.TokenType == JsonTokenType.StartArray)
        {
            var jsonArray = JsonArray.Parse(ref reader);
            return new MarkedStringsOrMarkupContent()
            {
                MarkedStrings = jsonArray.Deserialize<List<MarkedString>>(options)
            };
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            return new()
            {
                MarkedStrings = [new MarkedString() { Value = reader.GetString() ?? string.Empty }]
            };
        }

        return new();
    }

    public override void Write(Utf8JsonWriter writer, MarkedStringsOrMarkupContent value, JsonSerializerOptions options)
    {
        throw new NotSupportedException("It only use Deserialize.");
    }
}
