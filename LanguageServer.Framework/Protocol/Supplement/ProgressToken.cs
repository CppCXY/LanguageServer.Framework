using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

[JsonConverter(typeof(ProgressTokenJsonConverter))]
public sealed class ProgressToken : StringOrInt
{
    public ProgressToken(string value) : base(value)
    {
    }

    public ProgressToken(int value) : base(value)
    {
    }
}

public class ProgressTokenJsonConverter : JsonConverter<ProgressToken>
{
    public override ProgressToken Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return new ProgressToken(reader.GetInt32());
        }

        return new ProgressToken(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, ProgressToken value, JsonSerializerOptions options)
    {
        if (value.StringValue != null)
        {
            writer.WriteStringValue(value.StringValue);
        }
        else
        {
            writer.WriteNumberValue(value.IntValue);
        }
    }
}