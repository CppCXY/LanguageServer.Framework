using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;

/**
 * A code action represents a change that can be performed in code, e.g. to fix
 * a problem or to refactor code.
 *
 * A CodeAction must set either `edit` and/or a `command`. If both are supplied,
 * the `edit` is applied first, then the `command` is executed.
 */
public record CodeAction
{
    /**
     * A short, human-readable title for this code action.
     */
    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    /**
     * The kind of the code action.
     *
     * Used to filter code actions.
     */
    [JsonPropertyName("kind")]
    public CodeActionKind? Kind { get; set; }

    /**
     * The diagnostics that this code action resolves.
     */
    [JsonPropertyName("diagnostics")]
    public List<Diagnostic> Diagnostics { get; set; } = [];

    /**
     * Marks this as a preferred action. Preferred actions are used by the
     * `auto fix` command and can be targeted by keybindings.
     *
     * A quick fix should be marked preferred if it properly addresses the
     * underlying error. A refactoring should be marked preferred if it is the
     * most reasonable choice of actions to take.
     *
     * @since 3.15.0
     */
    [JsonPropertyName("isPreferred")]
    public bool? IsPreferred { get; set; }


    /**
     * Marks that the code action cannot currently be applied.
     *
     * Clients should follow the following guidelines regarding disabled code
     * actions:
     *
     * - Disabled code actions are not shown in automatic lightbulbs code
     *   action menus.
     *
     * - Disabled actions are shown as faded out in the code action menu when
     *   the user request a more specific type of code action, such as
     *   refactorings.
     *
     * - If the user has a keybinding that auto applies a code action and only
     *   a disabled code actions are returned, the client should show the user
     *   an error message with `reason` in the editor.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("disabled")]
    public CodeActionDisabled? Disabled { get; set; }

    /**
     * The workspace edit this code action performs.
     */
    [JsonPropertyName("edit")]
    public WorkspaceEdit? Edit { get; set; }

    /**
     * A command this code action executes. If a code action
     * provides an edit and a command, first the edit is
     * executed and then the command.
     */
    [JsonPropertyName("command")]
    public Command? Command { get; set; }

    /**
     * A data entry field that is preserved on a code action between
     * a `textDocument/codeAction` and a `codeAction/resolve` request.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}

public class CodeActionDisabled
{
    /**
     * Human readable description of why the code action is currently disabled.
     *
     * This is displayed in the code actions UI.
     */
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = null!;
}
