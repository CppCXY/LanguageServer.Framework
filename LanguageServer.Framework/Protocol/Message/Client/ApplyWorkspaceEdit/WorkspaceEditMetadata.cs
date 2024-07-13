using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ApplyWorkspaceEdit;

/**
 * Additional data about a workspace edit.
 *
 * @since 3.18.0
 * @proposed
 */
public class WorkspaceEditMetadata
{
    /**
     * Signal to the editor that this edit is a refactoring.
     */
    [JsonPropertyName("isRefactoring")]
    public bool? IsRefactoring { get; set; }
}
