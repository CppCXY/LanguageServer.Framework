using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ApplyWorkspaceEdit;

public class ApplyWorkspaceEditParams
{
    /**
     * An optional label of the workspace edit. This label is
     * presented in the user interface, for example, on an undo
     * stack to undo the workspace edit.
     */
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /**
     * The edits to apply.
     */
    [JsonPropertyName("edit")]
    public WorkspaceEdit Edit { get; set; } = null!;

    /**
     * Additional data about the edit.
     *
     * @since 3.18.0
     * @proposed
     */
    [JsonPropertyName("metadata")]
    public WorkspaceEditMetadata? Metadata { get; set; }
}
