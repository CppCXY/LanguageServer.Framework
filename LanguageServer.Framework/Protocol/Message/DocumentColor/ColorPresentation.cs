using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

public class ColorPresentation
{
    /**
     * The label of this color presentation. It will be shown on the color
     * picker header. By default, this is also the text that is inserted when
     * selecting this color presentation.
     */
    [JsonPropertyName("label")]
    public string Label { get; set; } = null!;

    /**
     * An [edit](#TextEdit) which is applied to a document when selecting
     * this presentation for the color.  When `falsy` the [label](#ColorPresentation.label)
     * is used.
     */
    [JsonPropertyName("textEdit")]
    public TextEdit? TextEdit { get; set; }

    /**
     * An optional array of additional [text edits](#TextEdit) that are applied
     * when selecting this color presentation. Edits must not overlap with the
     * main [edit](#ColorPresentation.textEdit) nor with themselves.
     */
    [JsonPropertyName("additionalTextEdits")]
    public List<TextEdit>? AdditionalTextEdits { get; set; }
}
