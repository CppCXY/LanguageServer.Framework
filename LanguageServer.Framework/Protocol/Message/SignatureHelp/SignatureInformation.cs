using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Union;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

/**
 * Represents the signature of something callable. A signature
 * can have a label, like a function-name, a doc-comment, and
 * a set of parameters.
 */
public class SignatureInformation
{
    /**
     * The label of this signature. Will be shown in the UI.
     */
    [JsonPropertyName("label")]
    public string Label { get; set; } = null!;

    /**
     * The human-readable doc-comment of this signature. Will be shown
     * in the UI but can be omitted.
     */
    [JsonPropertyName("documentation")]
    public StringOrMarkupContent? Documentation { get; set; }

    /**
     * The parameters of this signature.
     */
    [JsonPropertyName("parameters")]
    public List<ParameterInformation> Parameters { get; set; } = null!;

    /**
     * The index of the active parameter.
     *
     * If `null`, no parameter of the signature is active (for example, a named
     * argument that does not match any declared parameters). This is only valid
     * since 3.18.0 and if the client specifies the client capability
     * `textDocument.signatureHelp.noActiveParameterSupport === true`.
     *
     * If provided (or `null`), this is used in place of
     * `SignatureHelp.activeParameter`.
     *
     * @since 3.16.0
     */
    [JsonPropertyName("activeParameter")]
    public uint? ActiveParameter { get; set; }
}
