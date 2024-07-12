using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

[JsonConverter(typeof(DocumentColorResponseJsonConverter))]
public class DocumentColorResponse(List<ColorInformation> colorInformationList)
{
    public List<ColorInformation> ColorInformationList { get; set; } = colorInformationList;
}

public class DocumentColorResponseJsonConverter : JsonConverter<DocumentColorResponse>
{
    public override DocumentColorResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, DocumentColorResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.ColorInformationList, options);
    }
}
