using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

[JsonConverter(typeof(CompletionTriggerKindJsonConverter))]
public readonly record struct CompletionTriggerKind(int Value)
{
    /**
     * Completion was triggered by typing an identifier (automatic code
     * complete), manual invocation (e.g. Ctrl+Space) or via API.
     */
    public static CompletionTriggerKind Invoked => new(1);

    /**
     * Completion was triggered by a trigger character specified by
     * the `triggerCharacters` properties of the
     * `CompletionRegistrationOptions`.
     */
    public static CompletionTriggerKind TriggerCharacter => new(2);

    /**
     * Completion was re-triggered as the current completion list is incomplete.
     */
    public static CompletionTriggerKind TriggerForIncompleteCompletions => new(3);

    public int Value { get; } = Value;
}

public class CompletionTriggerKindJsonConverter : JsonConverter<CompletionTriggerKind>
{
    public override CompletionTriggerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return new CompletionTriggerKind(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, CompletionTriggerKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
