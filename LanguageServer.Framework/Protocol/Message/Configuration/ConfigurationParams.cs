using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Configuration;

public class ConfigurationParams
{
    [JsonPropertyName("items")]
    public List<ConfigurationItem> Items { get; set; } = null!;
}
