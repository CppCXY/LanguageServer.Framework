using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentLink;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class DocumentLinkHandler : DocumentLinkHandlerBase
{
    protected override Task<DocumentLinkResponse> Handle(DocumentLinkParams request, CancellationToken token)
    {
         Console.Error.WriteLine("DocumentLink");
         return  Task.FromResult(new DocumentLinkResponse([
             new DocumentLink()
             {
                 Range = new DocumentRange()
                 {
                     Start = new Position()
                     {
                         Line = 0,
                         Character = 0
                     },
                     End = new Position()
                     {
                         Line = 0,
                         Character = 1
                     }
                 },
                 Target = "https://www.google.com"
             }
         ]));
    }

    protected override Task<DocumentLink> Resolve(DocumentLink request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentLink/Resolve");
        return Task.FromResult(request);
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.DocumentLinkProvider = new DocumentLinkOptions()
        {
            ResolveProvider = true
        };
    }
}