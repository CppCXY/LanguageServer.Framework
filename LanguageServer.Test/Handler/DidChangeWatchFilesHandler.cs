using System.Text.Json;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Server;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Client.Registration;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile;
using EmmyLua.LanguageServer.Framework.Protocol.Message.WorkspaceWatchedFile.Watch;
using EmmyLua.LanguageServer.Framework.Server.Handler;

namespace EmmyLua.LanguageServer.Framework.Handler;

public class DidChangeWatchFilesHandler : DidChangeWatchedFilesHandlerBase
{
    protected override Task Handle(DidChangeWatchedFilesParams request, CancellationToken token)
    {
        Console.Error.WriteLine("DidChangeWatchFilesHandler.Handle");
        return Task.CompletedTask;
    }

    public override void RegisterCapability(ServerCapabilities serverCapabilities,
        ClientCapabilities clientCapabilities)
    {
    }

    public override void RegisterDynamicCapability(Server.LanguageServer server, ClientCapabilities clientCapabilities)
    {
        var dynamicRegistration = new DidChangeWatchedFilesRegistrationOptions()
        {
            Watchers =
            [
                new ()
                {
                    GlobalPattern = "**/*.lua",
                    Kind = WatchKind.Create | WatchKind.Change | WatchKind.Delete
                }
            ]
        };
        
        var jsonDocument = JsonSerializer.SerializeToDocument(dynamicRegistration, server.JsonSerializerOptions);
        
        server.Client.DynamicRegisterCapability(new RegistrationParams()
        {
            Registrations =
            [
                new Registration()
                {
                    Id = Guid.NewGuid().ToString(),
                    Method = "workspace/didChangeWatchedFiles",
                    RegisterOptions = jsonDocument
                }
            ]
        });
    }
}