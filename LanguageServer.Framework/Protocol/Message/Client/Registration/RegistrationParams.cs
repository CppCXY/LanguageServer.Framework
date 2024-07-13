using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Client.Registration;

public class RegistrationParams
{
    [JsonPropertyName("registrations")]
    public List<Registration> Registrations { get; set; } = null!;
}
