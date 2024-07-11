using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

[JsonConverter(typeof(TextEditOrInsertReplaceEditConverter))]
public class TextEditOrInsertReplaceEdit
{
    public TextEditOrInsertReplaceEdit(TextEdit.TextEdit textEdit)
    {
        TextEdit = textEdit;
    }

    public TextEditOrInsertReplaceEdit(InsertReplaceEdit insertReplaceEdit)
    {
        InsertReplaceEdit = insertReplaceEdit;
    }

    public TextEdit.TextEdit? TextEdit { get; set; }

    public InsertReplaceEdit? InsertReplaceEdit { get; set; }
}

public class TextEditOrInsertReplaceEditConverter : JsonConverter<TextEditOrInsertReplaceEdit>
{
    public override TextEditOrInsertReplaceEdit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var root = jsonDocument.RootElement;
        if (root.TryGetProperty("range", out _))
        {
            var textEdit = JsonSerializer.Deserialize<TextEdit.TextEdit>(root.GetRawText(), options);
            return new TextEditOrInsertReplaceEdit(textEdit!);
        }

        var insertReplaceEdit = JsonSerializer.Deserialize<InsertReplaceEdit>(root.GetRawText(), options);
        return new TextEditOrInsertReplaceEdit(insertReplaceEdit!);
    }

    public override void Write(Utf8JsonWriter writer, TextEditOrInsertReplaceEdit value, JsonSerializerOptions options)
    {
        if (value.TextEdit != null)
        {
            JsonSerializer.Serialize(writer, value.TextEdit, options);
        }
        else
        {
            JsonSerializer.Serialize(writer, value.InsertReplaceEdit, options);
        }
    }
}
