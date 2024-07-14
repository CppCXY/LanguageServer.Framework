﻿using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.DocumentHighlight;

namespace EmmyLua.LanguageServer.Framework.Server.Handler;

public abstract class DocumentHighlightHandlerBase : IJsonHandler
{
    protected abstract Task<DocumentHighlightResponse> Handle(DocumentHighlightParams request, CancellationToken token);

    public void RegisterHandler(LanguageServer server)
    {
        server.AddRequestHandler("textDocument/documentHighlight", async (message, token) =>
        {
            var request = message.Params!.Deserialize<DocumentHighlightParams>(server.JsonSerializerOptions)!;
            var r = await Handle(request, token);
            return JsonSerializer.SerializeToDocument(r, server.JsonSerializerOptions);
        });
    }

    public abstract void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities);

    public virtual void RegisterDynamicCapability(LanguageServer server, ClientCapabilities clientCapabilities)
    {
    }
}
