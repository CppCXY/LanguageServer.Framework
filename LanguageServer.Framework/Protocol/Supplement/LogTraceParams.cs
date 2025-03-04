using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public class LogTraceParams
{
    [JsonPropertyName("message")] public required string Message { get; init; }
    [JsonPropertyName("verbose")] public string? Verbose { get; init; }
}
