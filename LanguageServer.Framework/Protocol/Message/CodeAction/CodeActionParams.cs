using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;

public class CodeActionParams : IWorkDoneProgressParams, IPartialResultParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    [JsonPropertyName("partialResultToken")]
    public string? PartialResultToken { get; set; }

    /**
     * The document in which the command was invoked.
     */
    [JsonPropertyName("textDocument")]
    public TextDocumentIdentifier TextDocument { get; set; } = null!;

    /**
     * The document in which the command was invoked.
     */
    [JsonPropertyName("range")]
    public Range Range { get; set; }

    /**
     * Context carrying additional information.
     */
    [JsonPropertyName("context")]
    public CodeActionContext Context { get; set; } = null!;
}
