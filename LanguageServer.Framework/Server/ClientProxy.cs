using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ApplyWorkspaceEdit;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.Registration;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.ShowMessage;

namespace EmmyLua.LanguageServer.Framework.Server;

public class ClientProxy(LanguageServer server)
{
    public Task DynamicRegisterCapability(RegistrationParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var notification = new NotificationMessage("client/registerCapability", document);
        return server.SendNotification(notification);
    }

    public Task DynamicUnregisterCapability(UnregistrationParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var notification = new NotificationMessage("client/unregisterCapability", document);
        return server.SendNotification(notification);
    }

    public async Task<ApplyWorkspaceEditResult> ApplyEdit(ApplyWorkspaceEditParams @params, CancellationToken token)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var response = await server.SendRequest("workspace/applyEdit", document, token);
        return response!.Deserialize<ApplyWorkspaceEditResult>(server.JsonSerializerOptions)!;
    }

    public Task ShowMessage(ShowMessageParams @params)
    {
        var document = JsonSerializer.SerializeToDocument(@params, server.JsonSerializerOptions);
        var notification = new NotificationMessage("window/showMessage", document);
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

    public async Task<JsonDocument?> SendRequest(string method, JsonDocument document, CancellationToken token)
    {
        var response = server.SendRequest(method, document, token);
        return await response;
    }
}
