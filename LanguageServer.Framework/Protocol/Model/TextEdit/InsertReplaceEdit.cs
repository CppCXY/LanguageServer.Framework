using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;

/**
 * A special text edit to provide an insert and a replace operation.
 *
 * @since 3.16.0
 */
public class InsertReplaceEdit
{
    /**
     * The string to be inserted.
     */
    [JsonPropertyName("newText")]
    public string NewText { get; set; } = null!;

    /**
     * The range if the insert is requested
     */
    [JsonPropertyName("insert")]
    public DocumentRange Insert { get; set; }

    /**
     * The range if the replace is requested.
     */
    [JsonPropertyName("replace")]
    public DocumentRange Replace { get; set; }
}
