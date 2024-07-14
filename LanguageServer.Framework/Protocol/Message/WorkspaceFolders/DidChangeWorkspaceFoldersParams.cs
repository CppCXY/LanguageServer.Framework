using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceFolders;

public class DidChangeWorkspaceFoldersParams
{
    /**
     * The actual workspace folder change event.
     */
    [JsonPropertyName("event")]
    public WorkspaceFoldersChangeEvent Event { get; set; } = null!;
}
