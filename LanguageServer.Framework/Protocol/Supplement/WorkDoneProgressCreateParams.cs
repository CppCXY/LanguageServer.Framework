using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record WorkDoneProgressCreateParams
{
    [JsonPropertyName("token")] public required ProgressToken Token { get; init; }
}