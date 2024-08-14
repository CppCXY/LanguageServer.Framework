using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ApplyWorkspaceEdit;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.PublishDiagnostics;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.Registration;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ShowMessage;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Configuration;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Server;

public class ClientProxy(LanguageServer server)
{
    public Task DynamicRegisterCapability(RegistrationParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        server.SendRequestNoWait("client/registerCapability", document);
        return Task.CompletedTask;
    }

    public Task DynamicUnregisterCapability(UnregistrationParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        server.SendRequestNoWait("client/unregisterCapability", document);
        return Task.CompletedTask;
    }

    public async Task<ApplyWorkspaceEditResult> ApplyEdit(ApplyWorkspaceEditParams @params, CancellationToken token)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var response = await server.SendRequest("workspace/applyEdit", document, token);
        return response!.Deserialize<ApplyWorkspaceEditResult>(server.JsonSerializerOptions)!;
    }

    public async Task<List<LSPAny>> GetConfiguration(ConfigurationParams @params, CancellationToken token)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var response = await server.SendRequest("workspace/configuration", document, token);
        return response!.Deserialize<List<LSPAny>>(server.JsonSerializerOptions)!;
    }

    public Task ShowMessage(ShowMessageParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var notification = new NotificationMessage("window/showMessage", document);
        return server.SendNotification(notification);
    }

    public Task PublishDiagnostics(PublishDiagnosticsParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var notification = new NotificationMessage("textDocument/publishDiagnostics", document);
        return server.SendNotification(notification);
    }

    public async Task RefreshWorkspaceTokens()
    {
        await server.SendRequest("workspace/semanticTokens/refresh", null, CancellationToken.None);
    }

    public async Task RefreshInlineValues()
    {
        await server.SendRequest("workspace/inlineValue/refresh", null, CancellationToken.None);
    }

    public async Task RefreshInlayHint()
    {
        await server.SendRequest("workspace/inlayHint/refresh", null, CancellationToken.None);
    }

    public async Task RefreshDiagnostics()
    {
        await server.SendRequest("workspace/diagnostic/refresh", null, CancellationToken.None);
    }

    public async Task<JsonDocument?> SendRequest(string method, JsonDocument document, CancellationToken token)
    {
        var response = server.SendRequest(method, document, token);
        return await response;
    }
}
