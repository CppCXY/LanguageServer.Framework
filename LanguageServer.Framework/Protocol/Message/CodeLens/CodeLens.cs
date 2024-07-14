using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;


namespace EmmyLua.LanguageServer.Framework.Protocol.Message.CodeLens;

/**
 * A code lens represents a command that should be shown along with
 * source text, like the number of references, a way to run tests, etc.
 *
 * A code lens is _unresolved_ when no command is associated to it. For
 * performance reasons the creation of a code lens and resolving should be done
 * in two stages.
 */
public record CodeLens
{
    /**
     * The range in which this code lens is valid. Should only span a single
     * line.
     */
    [JsonPropertyName("range")]
    public DocumentRange Range { get; set; }

    /**
     * The command this code lens represents.
     */
    [JsonPropertyName("command")]
    public Command Command { get; set; } = null!;

    /**
     * A data entry field that is preserved on a code lens item between
     * a code lens and a code lens resolve request.
     */
    [JsonPropertyName("data")]
    public LSPAny? Data { get; set; }
}
