using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

public class CompletionParams : TextDocumentPositionParams, IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The completion context. This is only available if the client specifies
     * to send this using the client capability
     * `completion.contextSupport === true`
     */
    [JsonPropertyName("context")]
    public CompletionContext Context { get; set; } = null!;
}
