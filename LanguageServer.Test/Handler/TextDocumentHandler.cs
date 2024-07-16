using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server.Options;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.PublishDiagnostics;
using EmmyLua.LanguageServer.Framework.Protocol.Message.TextDocument;
using EmmyLua.LanguageServer.Framework.Protocol.Model;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Diagnostic;
using EmmyLua.LanguageServer.Framework.Protocol.Model.Kind;
using EmmyLua.LanguageServer.Framework.Protocol.Model.TextEdit;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class TextDocumentHandler(Server.LanguageServer server) : TextDocumentHandlerBase
{
    protected override Task Handle(DidOpenTextDocumentParams request, CancellationToken token)
    {
        Console.Error.WriteLine($"TextDocumentHandler: DidOpenTextDocument {request.TextDocument.Uri}");
        return Task.CompletedTask;
    }

    protected override Task Handle(DidChangeTextDocumentParams request, CancellationToken token)
    {
        Console.Error.WriteLine($"TextDocumentHandler: DidChangeTextDocument {request.TextDocument.Uri}");
        List<Diagnostic> diagnosticList =
        [
            new Diagnostic()
            {
                Message = "test",
                Range = new DocumentRange()
                {
                    Start = new Position()
                    {
                        Line = 0,
                        Character = 1
                    },
                    End = new Position()
                    {
                        Line = 0,
                        Character = 10
                    }
                },
                Severity = DiagnosticSeverity.Error,
                Source = "test",
                Code = "12313",
            }
        ];
        
        server.Client.PublishDiagnostics(new PublishDiagnosticsParams()
        {
            Uri = request.TextDocument.Uri,
            Diagnostics = diagnosticList
        });
        return Task.CompletedTask;
    }

    protected override Task Handle(DidCloseTextDocumentParams request, CancellationToken token)
    {
        Console.Error.WriteLine($"TextDocumentHandler: DidCloseTextDocument {request.TextDocument.Uri}");
        return Task.CompletedTask;
    }

    protected override Task Handle(WillSaveTextDocumentParams request, CancellationToken token)
    {
        Console.Error.WriteLine($"TextDocumentHandler: WillSaveTextDocument {request.TextDocument.Uri}");
        return Task.CompletedTask;
    }

    protected override Task<List<TextEdit>?> HandleRequest(WillSaveTextDocumentParams request, CancellationToken token)
    {
        Console.Error.WriteLine($"TextDocumentHandler: WillSaveTextDocumentRequest {request.TextDocument.Uri}");
        return Task.FromResult<List<TextEdit>?>(null);
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
        serverCapabilities.TextDocumentSync = new TextDocumentSyncOptions
        {
            Change = TextDocumentSyncKind.Full,
            OpenClose = true,
            WillSave = true,
            WillSaveWaitUntil = true,
            Save = true
        };
    }
}