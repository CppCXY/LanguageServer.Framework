using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.CodeLens;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using Range = EmmyLua.LanguageServer.Framework.Protocol.Model.Range;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class CodeLensHandler : CodeLensHandlerBase
{
    protected override Task<CodeLensResponse> Handle(CodeLensParams request, CancellationToken token)
    {
        Console.Error.WriteLine("CodeLens");
        return Task.FromResult(new CodeLensResponse([
            new CodeLens()
            {
                Range = new Range()
                {
                    Start = new Position()
                    {
                        Line = 0,
                        Character = 0
                    },
                    End = new Position()
                    {
                        Line = 0,
                        Character = 0
                    }
                },
                Command = new Command()
                {
                    Title = "CodeLens",
                    Name = "CodeLens",
                    Arguments = [1]
                }
            }
        ]));
    }

    protected override Task<CodeLens> Resolve(CodeLens request, CancellationToken token)
    {
        Console.Error.WriteLine("CodeLens/Resolve");
        return Task.FromResult(request);
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.CodeLensProvider = new CodeLensOptions()
        {
            ResolveProvider = true
        };
    }
}