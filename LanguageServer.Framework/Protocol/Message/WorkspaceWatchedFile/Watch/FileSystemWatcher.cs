using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;

public class FileSystemWatcher
{
    /**
     * The glob pattern to watch. See {@link GlobPattern glob pattern}
     * for more detail.
     *
     * @since 3.17.0 support for relative patterns.
     */
    [JsonPropertyName("globPattern")]
    public GlobalPattern GlobalPattern { get; set; } = null!;

    /**
     * The kind of events of interest. If omitted, it defaults
     * to WatchKind.Create | WatchKind.Change | WatchKind.Delete
     * which is 7.
     */
    [JsonPropertyName("kind")]
    public WatchKind Kind { get; set; }
}
