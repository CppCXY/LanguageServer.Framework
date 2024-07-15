using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Model;

[method: JsonConstructor]
public readonly record struct Location(DocumentUri Uri, DocumentRange Range)
{
    /**
     * The URI of the document.
     */
    [JsonPropertyName("uri")]
    public DocumentUri Uri { get; init; } = Uri;

    /**
     * The range in side the document.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; init; } = Range;
}
