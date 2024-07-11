using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;

/**
 * Contains additional information about the context in which a completion
 * request is triggered.
 */
public class CompletionContext
{
    /**
     * How the completion was triggered.
     */
    [JsonPropertyName("triggerKind")]
    public CompletionTriggerKind TriggerKind { get; set; }

    /**
     * The trigger character (a single character) that
     * has triggered code complete. Is undefined if
     * `triggerKind !== CompletionTriggerKind.TriggerCharacter`
     */
    [JsonPropertyName("triggerCharacter")]
    public string? TriggerCharacter { get; set; }
}
