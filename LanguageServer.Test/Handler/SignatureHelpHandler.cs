using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.SignatureHelp;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class SignatureHelpHandler : SignatureHelpHandlerBase
{
    protected override Task<SignatureHelp> Handle(SignatureHelpParams request, CancellationToken token)
    {
        Console.Error.WriteLine("SignatureHelp");
        var signatureHelpInfo = new SignatureInformation()
        {
            Label = "hi hi hi",
            Documentation = "hello world",
            ActiveParameter = 0,
            Parameters =
            [
                new ParameterInformation()
                {
                    Label = "hi",
                    Documentation = "param1 documentation"
                }
            ]
        };
        
        return Task.FromResult(new SignatureHelp()
        {
            Signatures = [signatureHelpInfo],
            ActiveSignature = 0,
            ActiveParameter = 0,
        });
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.SignatureHelpProvider = new SignatureHelpOptions
        {
            TriggerCharacters = new List<string> { "(", "," }
        };
    }
}