using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFiles;

/**
 * The parameters sent in notifications/requests for user-initiated creation
 * of files.
 *
 * @since 3.16.0
 */
public class CreateFilesParams
{

    /**
     * An array of all files/folders created in this operation.
     */
    [JsonPropertyName("files")]
    public List<FileCreate> Files { get; set; } = null!;
}

/**
 * Represents information on a file/folder create.
 *
 * @since 3.16.0
 */
public class FileCreate
{
    /**
     * A file:// URI for the location of the file/folder being created.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; set; }
}
