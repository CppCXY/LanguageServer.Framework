using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFiles;

/**
 * The parameters sent in notifications/requests for user-initiated renames
 * of files.
 *
 * @since 3.16.0
 */
public class RenameFilesParams
{
    /**
     * An array of all files/folders renamed in this operation. When a folder
     * is renamed, only the folder will be included, and not its children.
     */
    [JsonPropertyName("files")]
    public List<FileRename> Files { get; set; } = null!;
}

/**
 * Represents information on a file/folder rename.
 *
 * @since 3.16.0
 */
public class FileRename
{
    /**
     * A file:// URI for the location of the file/folder being renamed.
     */
    [JsonPropertyName("oldUri")]
    public DocumentUri OldUri { get; set; }

    /**
     * A file:// URI for the new location of the file/folder. If the new location
     * is already existing, it will be overwritten.
     */
    [JsonPropertyName("newUri")]
    public DocumentUri NewUri { get; set; }
}
