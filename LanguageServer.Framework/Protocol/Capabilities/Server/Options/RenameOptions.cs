using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;

public class RenameOptions : WorkDoneProgressOptions
{
    /**
     * Renames should be checked and tested before being executed.
     */
    [JsonPropertyName("prepareProvider")]
    public bool? PrepareProvider { get; set; }
}
