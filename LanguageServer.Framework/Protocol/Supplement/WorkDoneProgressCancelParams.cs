using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record WorkDoneProgressCancelParams
{
    [JsonPropertyName("token")] public required ProgressToken Token { get; init; }
}