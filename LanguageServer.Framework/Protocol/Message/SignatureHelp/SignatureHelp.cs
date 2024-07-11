using System.Text.Json.Serialization;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

/**
 * Signature help represents the signature of something
 * callable. There can be multiple signatures,
 * but only one active one and only one active parameter.
 */
public class SignatureHelp
{
    /**
     * One or more signatures. If no signatures are available,
     * the signature help request should return `null`.
     */
    [JsonPropertyName("signatures")]
    public List<SignatureInformation> Signatures { get; set; } = null!;

    /**
     * The active signature. If omitted or the value lies outside the
     * range of `signatures`, the value defaults to zero or is ignored if
     * the `SignatureHelp` has no signatures.
     *
     * Whenever possible, implementers should make an active decision about
     * the active signature and shouldn't rely on a default value.
     *
     * In future versions of the protocol, this property might become
     * mandatory to better express this.
     */
    [JsonPropertyName("activeSignature")]
    public uint? ActiveSignature { get; set; }

    /**
     * The active parameter of the active signature.
     *
     * If `null`, no parameter of the signature is active (for example, a named
     * argument that does not match any declared parameters). This is only valid
     * since 3.18.0 and if the client specifies the client capability
     * `textDocument.signatureHelp.noActiveParameterSupport === true`.
     *
     * If omitted or the value lies outside the range of
     * `signatures[activeSignature].parameters`, it defaults to 0 if the active
     * signature has parameters.
     *
     * If the active signature has no parameters, it is ignored.
     *
     * In future versions of the protocol this property might become
     * mandatory (but still nullable) to better express the active parameter if
     * the active signature does have any.
     */
    [JsonPropertyName("activeParameter")]
    public uint? ActiveParameter { get; set; }
}
