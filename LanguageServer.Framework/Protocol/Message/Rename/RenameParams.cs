using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Rename;

public class RenameParams : TextDocumentPositionParams, IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The new name of the symbol. If the given name is not valid, the
     * request must return a [ResponseError](#ResponseError) with an
     * appropriate message set.
     */
    [JsonPropertyName("newName")]
    public string NewName { get; set; } = null!;
}
