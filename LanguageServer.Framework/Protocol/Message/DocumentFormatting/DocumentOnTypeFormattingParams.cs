using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentFormatting;

public class DocumentOnTypeFormattingParams
{
    /**
     * The document to format.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The position at which this request was send.
     */
    [JsonPropertyName("position")]
    public Position Position { get; set; }

    /**
     * The character that has been typed.
     */
    [JsonPropertyName("ch")]
    public string Ch { get; set; } = null!;

    /**
     * The format options.
     */
    [JsonPropertyName("options")]
    public FormattingOptions Options { get; set; } = null!;
}
