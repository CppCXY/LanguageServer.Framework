using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

[JsonConverter(typeof(PrepareSupportDefaultBehaviorJsonConverter))]
public enum PrepareSupportDefaultBehavior
{
    /**
     * The client's default behavior is to select the identifier
     * according to the language's syntax rule.
     */
    Identifier = 1
}

public class PrepareSupportDefaultBehaviorJsonConverter : JsonConverter<PrepareSupportDefaultBehavior>
{
    public override PrepareSupportDefaultBehavior Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return (PrepareSupportDefaultBehavior)reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, PrepareSupportDefaultBehavior value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
