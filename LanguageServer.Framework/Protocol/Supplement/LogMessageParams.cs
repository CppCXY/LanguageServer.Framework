using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record LogMessageParams
{
    /// <summary>
    /// The message type. See {@link MessageType}
    /// </summary>
    [JsonPropertyName("type")]
    public MessageType Type { get; init; }

    /// <summary>
    /// The actual message
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}