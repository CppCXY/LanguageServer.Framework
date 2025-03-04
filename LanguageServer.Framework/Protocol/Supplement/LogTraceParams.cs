using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public class LogTraceParams
{
    [JsonPropertyName("message")] public required string Message { get; init; }
    [JsonPropertyName("verbose")] public string? Verbose { get; init; }
}