using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeLens;

[JsonConverter(typeof(CodeLensResponseJsonConverter))]
public class CodeLensResponse(List<CodeLens> codeLenses)
{
    public List<CodeLens> CodeLenses { get; set; } = codeLenses;
}

public class CodeLensResponseJsonConverter : JsonConverter<CodeLensResponse>
{
    public override CodeLensResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, CodeLensResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.CodeLenses, options);
    }
}
