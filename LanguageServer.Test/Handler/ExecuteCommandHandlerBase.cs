using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ShowMessage;
using EmmyLua.LanguageServer.Framework.Protocol.Message.ExecuteCommand;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class ExecuteCommandHandler(Server.LanguageServer server) : ExecuteCommandHandlerBase
{
    protected override Task<ExecuteCommandResponse> Handle(ExecuteCommandParams request, CancellationToken token)
    {
        Console.Error.WriteLine("ExecuteCommand");
        server.Client.ShowMessage(new ShowMessageParams()
        {
            Type = MessageType.Info,
            Message = "Hello world"
        });
        return Task.FromResult(new ExecuteCommandResponse(null));
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.ExecuteCommandProvider = new ExecuteCommandOptions
        {
            Commands = [
                "CodeLens"
            ]
        };
    }
}