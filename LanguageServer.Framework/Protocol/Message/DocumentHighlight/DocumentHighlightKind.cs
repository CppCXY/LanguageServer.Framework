using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentHighlight;

/**
 * A document highlight kind.
 */
[JsonConverter(typeof(DocumentHighlightKindJsonConverter))]
public readonly record struct DocumentHighlightKind(int Value)
{
    /**
     * A textual occurrence.
     */
    public static DocumentHighlightKind Text { get; } = new DocumentHighlightKind(1);

    /**
     * Read-access of a symbol, like reading a variable.
     */
    public static DocumentHighlightKind Read { get; } = new DocumentHighlightKind(2);

    /**
     * Write-access of a symbol, like writing to a variable.
     */
    public static DocumentHighlightKind Write { get; } = new DocumentHighlightKind(3);
}

public class DocumentHighlightKindJsonConverter : JsonConverter<DocumentHighlightKind>
{
    public override DocumentHighlightKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return new DocumentHighlightKind(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, DocumentHighlightKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
