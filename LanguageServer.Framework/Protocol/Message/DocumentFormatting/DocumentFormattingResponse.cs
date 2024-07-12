using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentFormatting;

[JsonConverter(typeof(DocumentFormattingResponseJsonConverter))]
public class DocumentFormattingResponse(List<TextEdit> edits)
{
    public List<TextEdit> Edits { get; set; } = edits;

    public DocumentFormattingResponse(TextEdit edit) : this([edit])
    {
    }
}

public class DocumentFormattingResponseJsonConverter : JsonConverter<DocumentFormattingResponse>
{
    public override DocumentFormattingResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, DocumentFormattingResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Edits, options);
    }
}
