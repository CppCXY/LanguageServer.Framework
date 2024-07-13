using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ShowMessage;

public class ShowMessageParams
{
    /**
     * The message type. See {@link MessageType}.
     */
    [JsonPropertyName("type")]
    public MessageType Type { get; set; }

    /**
     * The actual message.
     */
    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;
}
