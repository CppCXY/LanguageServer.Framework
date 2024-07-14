using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

/**
 * Represents a color in RGBA space.
 */
public class DocumentColor(double red, double green, double blue, double alpha = 0)
{
    /**
     * The red component of this color in the range [0-1].
     */
    [JsonPropertyName("red")]
    public double Red { get; set; } = red;

    /**
     * The green component of this color in the range [0-1].
     */
    [JsonPropertyName("green")]
    public double Green { get; set; } = green;

    /**
     * The blue component of this color in the range [0-1].
     */
    [JsonPropertyName("blue")]
    public double Blue { get; set; } = blue;

    /**
     * The alpha component of this color in the range [0-1].
     */
    [JsonPropertyName("alpha")]
    public double Alpha { get; set; } = alpha;

    public DocumentColor() : this(0, 0, 0, 0)
    {
    }
}
