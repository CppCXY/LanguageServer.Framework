using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Completion;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class CompletionHandler : CompletionHandlerBase
{
    protected override Task<CompletionResponse?> Handle(CompletionParams request, CancellationToken token)
    {
        Console.Error.WriteLine("CompletionHandler.Handle");
        return Task.FromResult(new CompletionResponse([
            new CompletionItem()
            {
                Label = "Hello",
                Kind = CompletionItemKind.Text,
                Detail = "Hello World",
                Documentation = "Hello World",
                InsertText = "Hello World",
                InsertTextFormat = InsertTextFormat.PlainText,
                SortText = "Hello",
                FilterText = "Hello",
            }
        ]))!;
    }

    protected override Task<CompletionItem> Resolve(CompletionItem item, CancellationToken token)
    {
        Console.Error.WriteLine("CompletionHandler.Resolve");
        return Task.FromResult(item)!;
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.CompletionProvider = new CompletionOptions()
        {
            TriggerCharacters = [".", "("],
            ResolveProvider = true
        };
    }
}