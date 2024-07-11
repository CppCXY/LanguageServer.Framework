using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextDocument;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.Hover;

public class HoverParams : TextDocumentPositionParams, IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }
}
