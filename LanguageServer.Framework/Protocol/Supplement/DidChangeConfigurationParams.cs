using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record DidChangeConfigurationParams
{
    /// <summary>
    /// The actual changed settings
    /// </summary>
    ///
    [JsonPropertyName("settings")]
    public LSPAny? Settings { get; init; }
}