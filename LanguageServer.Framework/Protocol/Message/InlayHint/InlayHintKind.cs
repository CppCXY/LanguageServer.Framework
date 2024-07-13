using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;

[JsonConverter(typeof(InlayHintKindJsonConverter))]
public readonly record struct InlayHintKind(int Value)
{
    /**
     * An inlay hint that is for a type annotation.
     */
    public static InlayHintKind Type = new(1);

    /**
     * An inlay hint that is for a parameter.
     */
    public static InlayHintKind Parameter = new(2);
}

public class InlayHintKindJsonConverter : JsonConverter<InlayHintKind>
{
    public override InlayHintKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return new InlayHintKind(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, InlayHintKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
