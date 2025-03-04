using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ShowMessage;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

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
