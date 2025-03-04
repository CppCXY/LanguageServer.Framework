using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record WorkDoneProgressCreateParams
{
    [JsonPropertyName("token")] public required ProgressToken Token { get; init; }
}