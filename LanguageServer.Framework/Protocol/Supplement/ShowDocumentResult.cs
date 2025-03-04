using System.Text.Json;
using System.Text.Json.Serialization;

namespace WCKYWCKF.EmmyLua.LanguageServer.Framework.ClientEx.Protocol;

public record ShowDocumentResult()
{
    /// <summary>
    /// A boolean indicating if the show was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; init; }
}