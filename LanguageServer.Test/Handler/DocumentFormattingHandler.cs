using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentFormatting;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class DocumentFormattingHandler : DocumentFormattingHandlerBase
{
    protected override Task<DocumentFormattingResponse?> Handle(DocumentFormattingParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentFormattingHandler.FormattingHandle");
        return Task.FromResult<DocumentFormattingResponse?>(null);
    }

    protected override Task<DocumentFormattingResponse?> Handle(DocumentRangeFormattingParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentFormattingHandler.RangeFormattingHandle");
        return Task.FromResult<DocumentFormattingResponse?>(null);
    }

    protected override Task<DocumentFormattingResponse?> Handle(DocumentRangesFormattingParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentFormattingHandler.RangesFormattingHandle");
        return Task.FromResult<DocumentFormattingResponse?>(null);
    }

    protected override Task<DocumentFormattingResponse?> Handle(DocumentOnTypeFormattingParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DocumentFormattingHandler.OnTypeFormattingHandle");
        return Task.FromResult<DocumentFormattingResponse?>(null);
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities, ClientCapabilities clientCapabilities)
    {
        serverCapabilities.DocumentFormattingProvider = true;

        serverCapabilities.DocumentRangeFormattingProvider = new DocumentRangeFormattingOptions()
        {
            RangesSupport = true
        };
        
        serverCapabilities.DocumentOnTypeFormattingProvider = new DocumentOnTypeFormattingOptions()
        {
            FirstTriggerCharacter = "a"
        };
    }
}