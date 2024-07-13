using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

/**
 * Describes how an {@link InlineCompletionItemProvider inline completion
 * provider} was triggered.
 *
 * @since 3.18.0
 */
[JsonConverter(typeof(InlineCompletionTriggerKindConverter))]
public readonly record struct InlineCompletionTriggerKind(int Value)
{
    /**
     * Completion was triggered explicitly by a user gesture.
     * Return multiple completion items to enable cycling through them.
     */
    public static InlineCompletionTriggerKind Invoked = new(1);

    /**
     * Completion was triggered automatically while editing.
     * It is sufficient to return a single completion item in this case.
     */
    public static InlineCompletionTriggerKind Automatic = new(2);
}

public class InlineCompletionTriggerKindConverter : JsonConverter<InlineCompletionTriggerKind>
{
    public override InlineCompletionTriggerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetInt32() switch
        {
            1 => InlineCompletionTriggerKind.Invoked,
            2 => InlineCompletionTriggerKind.Automatic,
            _ => throw new JsonException(),
        };
    }

    public override void Write(Utf8JsonWriter writer, InlineCompletionTriggerKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
