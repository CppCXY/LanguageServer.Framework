using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public record ShowDocumentResult()
{
    /// <summary>
    /// A boolean indicating if the show was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; init; }
}