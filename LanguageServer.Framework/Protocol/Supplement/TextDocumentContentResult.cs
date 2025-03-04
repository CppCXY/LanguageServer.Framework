using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record TextDocumentContentResult
{
    [JsonPropertyName("text")] public required string Text { get; init; }
}