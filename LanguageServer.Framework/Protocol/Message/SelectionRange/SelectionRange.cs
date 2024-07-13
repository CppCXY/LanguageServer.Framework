using System.Text.Json.Serialization;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SelectionRange;

public class SelectionRange
{
    /**
     * The [range](#Range) of this selection range.
     */
    [JsonPropertyName("range")]
    public Range Range { get; set; }

    /**
     * The parent selection range containing this range. Therefore `parent.range` must contain `this.range`.
     */
    [JsonPropertyName("parent")]
    public SelectionRange? Parent { get; set; }
}
