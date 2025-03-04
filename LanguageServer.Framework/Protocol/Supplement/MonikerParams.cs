using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Supplement;

public sealed class MonikerParams : TextDocumentPositionParams, IWorkDoneProgressParams, IPartialResultParams
{
    public string? WorkDoneToken { get; set; }
    public string? PartialResultToken { get; set; }
}