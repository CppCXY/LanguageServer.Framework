using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile;

using FileSystemWatcher =
    EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch.FileSystemWatcher;

/**
 * Describe options to be used when registering for file system change events.
 */
public class DidChangeWatchedFilesRegistrationOptions
{
    /**
     * The watchers to register.
     */
    [JsonPropertyName("watchers")]
    public List<FileSystemWatcher> Watchers { get; set; } = null!;
}
