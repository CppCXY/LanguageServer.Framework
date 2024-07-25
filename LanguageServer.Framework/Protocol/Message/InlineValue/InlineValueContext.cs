using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

/**
 * @since 3.17.0
 */
public class InlineValueContext
{
    /**
     * The stack frame (as a DAP ID) where the execution has stopped.
     */
    [JsonPropertyName("frameId")]
    public int FrameId { get; set; }

    /**
     * The document range where execution has stopped.
     * Typically, the end position of the range denotes the line where the
     * inline values are shown.
     */
    [JsonPropertyName("stoppedLocation")]
    public DocumentRange StoppedLocation { get; set; }
}
