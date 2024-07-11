using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

/**
 * Completion item tags are extra annotations that tweak the rendering of a
 * completion item.
 *
 * @since 3.15.0
 */
[JsonConverter(typeof(CompletionItemTagJsonConverter))]
public readonly record struct CompletionItemTag(int Value)
{
    /**
     * Render a completion as obsolete, usually using a strike-out.
     */
    public static CompletionItemTag Deprecated { get; } = new(1);

    public int Value { get; } = Value;
}

public class CompletionItemTagJsonConverter : JsonConverter<CompletionItemTag>
{
    public override CompletionItemTag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return new CompletionItemTag(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, CompletionItemTag value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
