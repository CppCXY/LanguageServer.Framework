using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;

[JsonConverter(typeof(InsertTextFormatJsonConverter))]
public readonly record struct InsertTextFormat(int Value)
{
    /**
     * The primary text to be inserted is treated as a plain string.
     */
    public static InsertTextFormat PlainText { get; } = new(1);

    /**
     * The primary text to be inserted is treated as a snippet.
     *
     * A snippet can define tab stops and placeholders with `$1`, `$2`
     * and `${3:foo}`. `$0` defines the final tab stop, it defaults to
     * the end of the snippet. Placeholders with equal identifiers are linked,
     * that is typing in one will update others too.
     */
    public static InsertTextFormat Snippet { get; } = new(2);

    public int Value { get; } = Value;
}

public class InsertTextFormatJsonConverter : JsonConverter<InsertTextFormat>
{
    public override InsertTextFormat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return new InsertTextFormat(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, InsertTextFormat value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
