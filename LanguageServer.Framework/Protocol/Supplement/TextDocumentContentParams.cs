using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record TextDocumentContentParams
{
    [JsonPropertyName("uri")] public required DocumentUri Uri { get; init; }
}