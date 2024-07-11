using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;

public class SignatureHelpParams : TextDocumentPositionParams, IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The signature help context. This is only available if the client
     * specifies to send this using the client capability
     * `textDocument.signatureHelp.contextSupport === true`
     *
     * @since 3.15.0
     */
    [JsonPropertyName("context")]
    public SignatureHelpContext? Context { get; set; }
}
