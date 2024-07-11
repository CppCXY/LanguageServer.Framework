using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;

/**
 * The reason why code actions were requested.
 *
 * @since 3.17.0
 */
[JsonConverter(typeof(CodeActionTriggerKindJsonConverter))]
public record struct CodeActionTriggerKind(int Value)
{
    /**
     * Code actions were explicitly requested by the user or by an extension.
     */
    public static readonly CodeActionTriggerKind Invoked = new(1);

    /**
     * Code actions were requested automatically.
     *
     * This typically happens when the current selection in a file changes,
     * but can also be triggered when file content changes.
     */
    public static readonly CodeActionTriggerKind Automatic = new(2);

    public int Value { get; } = Value;
}

public class CodeActionTriggerKindJsonConverter : JsonConverter<CodeActionTriggerKind>
{
    public override CodeActionTriggerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetInt32() switch
        {
            1 => CodeActionTriggerKind.Invoked,
            2 => CodeActionTriggerKind.Automatic,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, CodeActionTriggerKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
