using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

[JsonConverter(typeof(SignatureHelpTriggerKindJsonConverter))]
public enum SignatureHelpTriggerKind
{
    /**
     * Signature help was invoked manually by the user or by a command.
     */
    Invoked = 1,

    /**
     * Signature help was triggered by the cursor moving or by the document content changing.
     */
    TriggerCharacter = 2,

    /**
     * Signature help was triggered by the cursor moving or by the document
     * content changing.
     */
    ContentChange = 3
}

public class SignatureHelpTriggerKindJsonConverter : JsonConverter<SignatureHelpTriggerKind>
{
    public override SignatureHelpTriggerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return (SignatureHelpTriggerKind)reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, SignatureHelpTriggerKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
