using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;

/**
 * An event describing a file change.
 */
public class FileEvent
{
    /**
     * The file's URI.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }

    /**
     * The change type.
     */
    [JsonPropertyName("type")]
    public FileChangeType Type { get; set; }
}
