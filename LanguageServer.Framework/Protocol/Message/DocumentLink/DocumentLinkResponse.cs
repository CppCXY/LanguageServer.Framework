using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentLink;

[JsonConverter(typeof(DocumentLinkResponseJsonConverter))]
public class DocumentLinkResponse(List<DocumentLink> documentLinks)
{
    public List<DocumentLink> DocumentLinks { get; set; } = documentLinks;
}

public class DocumentLinkResponseJsonConverter : JsonConverter<DocumentLinkResponse>
{
    public override DocumentLinkResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, DocumentLinkResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.DocumentLinks, options);
    }
}
