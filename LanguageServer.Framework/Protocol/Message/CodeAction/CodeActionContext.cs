using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;

/**
 * Contains additional diagnostic information about the context in which
 * a code action is run.
 */
public class CodeActionContext
{
    /**
     * An array of diagnostics known on the client side overlapping the range
     * provided to the `textDocument/codeAction` request. They are provided so
     * that the server knows which errors are currently presented to the user
     * for the given range. There is no guarantee that these accurately reflect
     * the error state of the resource. The primary parameter
     * to compute code actions is the provided range.
     *
     * Note that the client should check the `textDocument.diagnostic.markupMessageSupport`
     * server capability before sending diagnostics with markup messages to a server.
     * Diagnostics with markup messages should be excluded for servers that don't support
     * them.
     */
    [JsonPropertyName("diagnostics")]
    public List<Diagnostic> Diagnostics { get; set; } = null!;

    /**
     * Requested kind of actions to return.
     *
     * Actions not of this kind are filtered out by the client before being
     * shown, so servers can omit computing them.
     */
    [JsonPropertyName("only")]
    public List<CodeActionKind>? Only { get; set; }

    /**
     * The reason why code actions were requested.
     *
     * @since 3.17.0
     */
    [JsonPropertyName("triggerKind")]
    public CodeActionTriggerKind? TriggerKind { get; set; }
}
