using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record MessageActionItem
{
    [JsonPropertyName("title")] public required string Title { get; init; }
}