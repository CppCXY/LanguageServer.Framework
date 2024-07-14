using System.Drawing;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

public class ColorInformation
{
    /**
 * The range in the document where this color appears.
 */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The actual color value for this color range.
     */
    [JsonPropertyName("color")]
    public DocumentColor Color { get; set; } = null!;
}
