using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.InlineCompletion;

/**
 * A parameter literal used in inline completion requests.
 *
 * @since 3.18.0
 */
public class InlineCompletionParams : TextDocumentPositionParams, IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * Additional information about the context in which inline completions
     * were requested.
     */
    [JsonPropertyName("context")]
    public InlineCompletionContext Context { get; set; } = null!;
}
