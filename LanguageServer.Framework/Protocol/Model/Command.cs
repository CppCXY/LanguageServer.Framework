using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

// ReSharper disable once InconsistentNaming
public record Command
{
    /**
     * Title of the command, like `save`.
     */
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /**
     * The command's identifier.
     */
    [JsonPropertyName("toolTip")]
    public string? ToolTip { get; set; } = null;

    /**
     * The identifier of the actual command handler.
     */
    [JsonPropertyName("command")]
    // ReSharper disable once InconsistentNaming
    public string Name { get; set; } = string.Empty;

    /**
     * Arguments that the command handler should be
     * invoked with.
     */
    [JsonPropertyName("arguments")]
    public List<LSPAny>? Arguments { get; set; } = null;
}
