using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ApplyWorkspaceEdit;

public class ApplyWorkspaceEditResult
{
    /**
     * Indicates whether the edit was applied or not.
     */
    [JsonPropertyName("applied")]
    public bool Applied { get; set; }

    /**
     * An optional textual description for why the edit was not applied.
     * This may be used by the server for diagnostic logging or to provide
     * a suitable error for a request that triggered the edit.
     */
    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }

    /**
     * Depending on the client's failure handling strategy, `failedChange`
     * might contain the index of the change that failed. This property is
     * only available if the client signals a `failureHandling` strategy
     * in its client capabilities.
     */
    [JsonPropertyName("failedChange")]
    public uint? FailedChange { get; set; }
}
