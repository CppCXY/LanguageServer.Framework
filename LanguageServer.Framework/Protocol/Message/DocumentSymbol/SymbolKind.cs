using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;

[JsonConverter(typeof(SymbolKindJsonConverter))]
public enum SymbolKind
{
    File = 1,
    Module = 2,
    Namespace = 3,
    Package = 4,
    Class = 5,
    Method = 6,
    Property = 7,
    Field = 8,
    Constructor = 9,
    Enum = 10,
    Interface = 11,
    Function = 12,
    Variable = 13,
    Constant = 14,
    String = 15,
    Number = 16,
    Boolean = 17,
    Array = 18,
    Object = 19,
    Key = 20,
    Null = 21,
    EnumMember = 22,
    Struct = 23,
    Event = 24,
    Operator = 25,
    TypeParameter = 26
}

public class SymbolKindJsonConverter : JsonConverter<SymbolKind>
{
    public override SymbolKind Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException();
        }

        return (SymbolKind)reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, SymbolKind value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value);
    }
}
