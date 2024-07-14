using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFiles;

/**
 * The parameters sent in notifications/requests for user-initiated deletes
 * of files.
 *
 * @since 3.16.0
 */
public class DeleteFilesParams
{
    /**
     * An array of all files/folders deleted in this operation.
     */
    [JsonPropertyName("files")]
    public List<FileDelete> Files { get; set; } = null!;
}

/**
 * Represents information on a file/folder delete.
 *
 * @since 3.16.0
 */
public class FileDelete
{
    /**
     * A file:// URI for the location of the file/folder being deleted.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }
}
