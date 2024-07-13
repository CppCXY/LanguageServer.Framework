using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Interface;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.ExecuteCommand;

public class ExecuteCommandParams : IWorkDoneProgressParams
{
    [JsonPropertyName("workDoneToken")]
    public string? WorkDoneToken { get; set; }

    /**
     * The identifier of the actual command handler.
     */
    [JsonPropertyName("command")]
    public string Command { get; set; } = null!;

    /**
     * Arguments that the command should be invoked with.
     */
    [JsonPropertyName("arguments")]
    public List<LSPAny>? Arguments { get; set; }
}
