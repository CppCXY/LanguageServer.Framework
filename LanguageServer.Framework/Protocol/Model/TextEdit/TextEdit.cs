using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;

public class TextEdit
{
    /**
     * The range of the text document to be manipulated. To insert
     * text into a document create a range where start === end.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The string to be inserted. For delete operations use an
     * empty string.
     */
    [JsonPropertyName("newText")]
    public string NewText { get; set; } = string.Empty;
}
