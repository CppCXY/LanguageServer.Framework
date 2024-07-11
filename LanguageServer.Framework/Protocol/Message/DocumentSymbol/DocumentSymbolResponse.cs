using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentSymbol;

[JsonConverter(typeof(DocumentSymbolResponseJsonConverter))]
public class DocumentSymbolResponse(List<DocumentSymbol> result1)
{
    public List<DocumentSymbol> Result1 { get; set; } = result1;

    // @deprecated use DocumentSymbol instead.
    // public List<SymbolInformation> Result2 { get; set; } = null!;
}

public class DocumentSymbolResponseJsonConverter : JsonConverter<DocumentSymbolResponse>
{
    public override DocumentSymbolResponse Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, DocumentSymbolResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Result1, options);
    }
}
