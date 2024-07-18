using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceSymbol;

[JsonConverter(typeof(WorkspaceSymbolResponseJsonConverter))]
public class WorkspaceSymbolResponse(List<WorkspaceSymbol> symbols)
{
    // also has SymbolInformation[] but deprecated

    public List<WorkspaceSymbol> Symbols { get; set; } = symbols;
}

public class WorkspaceSymbolResponseJsonConverter : JsonConverter<WorkspaceSymbolResponse>
{
    public override WorkspaceSymbolResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, WorkspaceSymbolResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Symbols, options);
    }
}
