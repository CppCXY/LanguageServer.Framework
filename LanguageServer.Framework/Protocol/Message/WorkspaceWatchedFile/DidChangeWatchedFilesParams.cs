using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile;

public class DidChangeWatchedFilesParams
{
    /**
     * The actual file events.
     */
    [JsonPropertyName("changes")]
    public List<FileEvent> Changes { get; set; } = null!;
}
