using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record TextDocumentContentRefreshParams()
{
    [JsonPropertyName("uri")] public required DocumentUri Uri { get; init; }
}