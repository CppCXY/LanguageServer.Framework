using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Configuration;

public class ConfigurationItem
{
    /**
     * The scope to get the configuration section for.
     */
    [JsonPropertyName("scopeUri")]
    public DocumentUri? ScopeUri { get; set; }

    /**
     * The configuration section asked for.
     */
    [JsonPropertyName("section")]
    public string? Section { get; set; }
}
