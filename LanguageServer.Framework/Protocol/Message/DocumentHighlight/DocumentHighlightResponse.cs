using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentHighlight;

[JsonConverter(typeof(DocumentHighlightResponseJsonConverter))]
public class DocumentHighlightResponse(List<DocumentHighlight> highlights)
{
    public List<DocumentHighlight> Highlights { get; set; } = highlights;
}

public class DocumentHighlightResponseJsonConverter : JsonConverter<DocumentHighlightResponse>
{
    public override DocumentHighlightResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, DocumentHighlightResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Highlights, options);
    }
}
