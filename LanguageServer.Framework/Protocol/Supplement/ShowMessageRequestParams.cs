using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record ShowMessageRequestParams
{
    /// <summary>
    /// The message type. See {@link MessageType}
    /// </summary>
    [JsonPropertyName("type")]
    public required MessageType Type { get; init; }

    /// <summary>
    /// The actual message
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }

    /// <summary>
    /// The message action items to present.
    /// </summary>
    [JsonPropertyName("actions")]
    public List<MessageActionItem>? Actions { get; init; }
}