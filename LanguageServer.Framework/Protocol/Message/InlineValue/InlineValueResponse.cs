using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

[JsonConverter(typeof(InlineValueResponseJsonConverter))]
public class InlineValueResponse(List<InlineValue> inlineValues)
{
    public List<InlineValue> InlineValues { get; set; } = inlineValues;
}

public class InlineValueResponseJsonConverter : JsonConverter<InlineValueResponse>
{
    public override InlineValueResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, InlineValueResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.InlineValues, options);
    }
}
