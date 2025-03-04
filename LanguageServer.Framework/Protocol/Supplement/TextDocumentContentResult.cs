using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record TextDocumentContentResult
{
    [JsonPropertyName("text")] public required string Text { get; init; }
}