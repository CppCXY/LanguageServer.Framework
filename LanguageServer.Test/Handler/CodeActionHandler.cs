using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.CodeAction;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class CodeActionHandler : CodeActionHandlerBase
{
    protected override Task<CodeActionResponse> Handle(CodeActionParams request, CancellationToken token)
    {
        Console.Error.WriteLine("CodeAction");
        return Task.FromResult(new CodeActionResponse([
            new Command()
            {
                Title = "CodeAction",
                Name = "CodeAction",
                Arguments = [1]
            }
        ]));
    }

    protected override Task<CodeAction> Resolve(CodeAction request, CancellationToken token)
    {
        Console.Error.WriteLine("CodeAction/Resolve");
        return Task.FromResult(request);
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.CodeActionProvider = new CodeActionOptions()
        {
            CodeActionKinds = [CodeActionKind.QuickFix]
        };
    }
}