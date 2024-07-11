﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

[JsonConverter(typeof(SignatureHelpTriggerKindJsonConverter))]
public readonly record struct SignatureHelpTriggerKind(int Value)
{
    /**
     * Signature help was invoked manually by the user or by a command.
     */
    public static readonly SignatureHelpTriggerKind Invoked = new(1);

    /**
     * Signature help was triggered by the cursor moving or by the document content changing.
     */
    public static readonly SignatureHelpTriggerKind TriggerCharacter = new(2);

    /**
     * Signature help was triggered by the cursor moving or by the document
     * content changing.
     */
    public static readonly SignatureHelpTriggerKind ContentChange = new(3);

    public int Value { get; } = Value;
}

public class SignatureHelpTriggerKindJsonConverter : JsonConverter<SignatureHelpTriggerKind>
{
    public override SignatureHelpTriggerKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return new SignatureHelpTriggerKind(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, SignatureHelpTriggerKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
