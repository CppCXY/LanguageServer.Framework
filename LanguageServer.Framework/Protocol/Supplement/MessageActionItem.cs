using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record MessageActionItem
{
    [JsonPropertyName("title")] public required string Title { get; init; }
}