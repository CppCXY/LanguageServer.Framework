using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentColor;

public class ColorPresentationParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("textDocument")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The text document.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The color information to request presentations for.
     */
    [JsonPropertyName("color")]
    public Color Color { get; set; } = null!;

    /**
     * The range where this color appears. Should only be provided if the color
     * information's range does not span the whole word.
     */
    [JsonPropertyName("range")]
    public Range? Range { get; set; }
}
