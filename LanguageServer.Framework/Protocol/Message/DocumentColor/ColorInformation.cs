using System.Drawing;
using System.Text.Json.Serialization;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

public class ColorInformation
{
    /**
 * The range in the document where this color appears.
 */
    [JsonPropertyName("range")]
    public Range Range { get; set; }

    /**
     * The actual color value for this color range.
     */
    [JsonPropertyName("color")]
    public Color Color { get; set; } = null!;
}
