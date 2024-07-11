using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

/**
 * Additional information about the context in which a signature help request
 * was triggered.
 *
 * @since 3.15.0
 */
public class SignatureHelpContext
{
    /**
     * Action that caused signature help to be triggered.
     */
    [JsonPropertyName("triggerKind")]
    public SignatureHelpTriggerKind TriggerKind { get; set; }

    /**
     * Character that caused signature help to be triggered.
     *
     * This is undefined when triggerKind !==
     * SignatureHelpTriggerKind.TriggerCharacter
     */
    [JsonPropertyName("triggerCharacter")]
    public string? TriggerCharacter { get; set; }

    /**
     * `true` if signature help was already showing when it was triggered.
     *
     * Retriggers occur when the signature help is already active and can be
     * caused by actions such as typing a trigger character, a cursor move, or
     * document content changes.
     */
    [JsonPropertyName("isRetrigger")]
    public bool IsRetrigger { get; set; }

    /**
     * The currently active `SignatureHelp`.
     *
     * The `activeSignatureHelp` has its `SignatureHelp.activeSignature` field
     * updated based on the user navigating through available signatures.
     */
    [JsonPropertyName("activeSignatureHelp")]
    public SignatureHelp? ActiveSignatureHelp { get; set; }
}
