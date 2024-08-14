using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineValue;

/**
 * A parameter literal used in inline value requests.
 *
 * @since 3.17.0
 */
public class InlineValueParams : IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The text document.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The document range for which inline values should be computed.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * Additional information about the context in which inline values were
     * requested.
     */
    [JsonPropertyName("context")]
    public InlineValueContext Context { get; set; } = null!;
}
