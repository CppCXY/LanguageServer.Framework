using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlayHint;

/**
 * A parameter literal used in inlay hint requests.
 *
 * @since 3.17.0
 */
public class InlayHintParams : IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The document to provide inlay hints for.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The range in which inlay hints should be shown.
     */
    [JsonPropertyName("range")]
    public Range Range { get; set; }
}
