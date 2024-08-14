using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Message;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Initialize;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using EmmyLua.LanguageServer.Framework.Server.JsonProtocol;
using EmmyLua.LanguageServer.Framework.Server.RequestManager;
using EmmyLua.LanguageServer.Framework.Server.Scheduler;

namespace EmmyLua.LanguageServer.Framework.Server;

public class LanguageServer
{
    public JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        TypeInfoResolver = JsonProtocolContext.Default,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private JsonProtocolReader Reader { get; }

    private JsonProtocolWriter Writer { get; }

    enum RunningState
    {
        Running,
        Shutdown,
        Exit
    }

    private RunningState State { get; set; }

    private IScheduler Scheduler { get; set; } = new SingleThreadScheduler();

    private ClientRequestTokenManager ClientRequestTokenManager { get; } = new();

    private ServerRequestManager ServerRequestManager { get; } = new();

    // ReSharper disable once CollectionNeverQueried.Local
    internal List<IJsonHandler> Handlers { get; } = new();

    private Dictionary<string, Func<RequestMessage, CancellationToken, Task<JsonDocument?>>> RequestHandlers { get; } =
        new();

    private Dictionary<string, Func<NotificationMessage, CancellationToken, Task>> NotificationHandlers { get; } = new();

    public ClientProxy Client { get; }

    public ClientCapabilities ClientCapabilities { get; set; }= null!;

    private LanguageServer(Stream input, Stream output)
    {
        Reader = new JsonProtocolReader(input, JsonSerializerOptions);
        Writer = new JsonProtocolWriter(output, JsonSerializerOptions);
        Client = new ClientProxy(this);
        AddHandler(new InitializeHandler(this));
    }

    public static LanguageServer From(Stream input, Stream output)
    {
        return new LanguageServer(input, output);
    }

    public void SetScheduler(IScheduler scheduler)
    {
        Scheduler = scheduler;
    }

    public void AddJsonSerializeContext(JsonSerializerContext serializerContext)
    {
        JsonSerializerOptions.TypeInfoResolverChain.Add(serializerContext);
    }

    public void AddRequestHandler(string method, Func<RequestMessage, CancellationToken, Task<JsonDocument?>> handler)
    {
        RequestHandlers[method] = handler;
    }

    public void AddNotificationHandler(string method, Func<NotificationMessage, CancellationToken, Task> handler)
    {
        NotificationHandlers[method] = handler;
    }

    public LanguageServer AddHandler(IJsonHandler handler)
    {
        Handlers.Add(handler);
        handler.RegisterHandler(this);
        return this;
    }

    public Task SendNotification(NotificationMessage notification)
    {
        Writer.WriteNotification(notification);
        return Task.CompletedTask;
    }

    public async Task<JsonDocument?> SendRequest(string method, JsonDocument? @param, CancellationToken token)
    {
        var request = ServerRequestManager.MakeRequest(method, @param);
        Writer.WriteRequest(request);
        return await ServerRequestManager.WaitResponse(request.Id, token);
    }

    public Task SendRequestNoWait(string method, JsonDocument? @param)
    {
        var request = ServerRequestManager.MakeRequest(method, @param);
        Writer.WriteRequest(request);
        return Task.CompletedTask;
    }

    public delegate Task InitializeEvent(InitializeParams request, ServerInfo serverInfo);

    internal InitializeEvent? InitializeEventDelegate;

    public void OnInitialize(InitializeEvent handler)
    {
        InitializeEventDelegate += handler;
    }

    public delegate Task InitializedEvent(InitializedParams request);

    internal InitializedEvent? InitializedEventDelegate;

    public void OnInitialized(InitializedEvent handler)
    {
        InitializedEventDelegate += handler;
    }

    public delegate Task ShutdownEvent();

    internal ShutdownEvent? ShutdownEventDelegate;

    public void OnShutdown(ShutdownEvent handler)
    {
        ShutdownEventDelegate += handler;
    }

    // public delegate void StartEvent();
    //
    // internal StartEvent? StartEventDelegate;
    //
    // public void OnStart(StartEvent handler)
    // {
    //     StartEventDelegate += handler;
    // }

    private async Task OnDispatch(Message message)
    {
        switch (message)
        {
            case RequestMessage request:
            {
                if (RequestHandlers.TryGetValue(request.Method, out var handler))
                {
                    try
                    {
                        var token = ClientRequestTokenManager.Create(request.Id);
                        var result = await handler(request, token).ConfigureAwait(false);
                        if (!token.IsCancellationRequested)
                        {
                            Writer.WriteResponse(request.Id, result);
                        }
                        else
                        {
                            Writer.WriteResponse(request.Id, null, new ResponseError(
                                ErrorCodes.RequestCancelled,
                                "Request cancelled",
                                null));
                        }
                    }
                    catch (JsonException e)
                    {
                        Console.Error.WriteLine(e);
                        Writer.WriteResponse(request.Id, null, new ResponseError(
                            ErrorCodes.ParseError,
                            e.Message,
                            null));
                    }
                    catch (OperationCanceledException)
                    {
                        Writer.WriteResponse(request.Id, null, new ResponseError(
                            ErrorCodes.RequestCancelled,
                            "Request cancelled",
                            null));
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                        Writer.WriteResponse(request.Id, null, new ResponseError(
                            ErrorCodes.InternalError,
                            e.Message,
                            null));
                    }
                    finally
                    {
                        ClientRequestTokenManager.ClearToken(request.Id);
                    }
                }
                else
                {
                    await Console.Error.WriteLineAsync($"Method {request.Method} not found");
                    Writer.WriteResponse(request.Id, null, new ResponseError(
                        ErrorCodes.MethodNotFound,
                        $"Method {request.Method} not found",
                        null));
                }

                break;
            }
            case NotificationMessage notification:
            {
                if (NotificationHandlers.TryGetValue(notification.Method, out var handler))
                {
                    await handler(notification, CancellationToken.None);
                }

                break;
            }
            case ResponseMessage response:
            {
                ServerRequestManager.OnResponse(response.Id, response.Result);
                break;
            }
        }
    }

    private bool BaseHandle(Message message)
    {
        if (message is RequestMessage requestMessage)
        {
            if (requestMessage.Method == "shutdown")
            {
                State = RunningState.Shutdown;
                ShutdownEventDelegate?.Invoke();
                Writer.WriteResponse(requestMessage.Id, null);
                return true;
            }
        }
        else if (message is NotificationMessage notification)
        {
            if (notification.Method == "exit")
            {
                Environment.Exit(State == RunningState.Shutdown ? 0 : 1);
            }
            else if (notification.Method == "$/cancelRequest")
            {
                var cancelParams = notification.Params?.Deserialize<CancelParams>(JsonSerializerOptions);
                if (cancelParams != null)
                {
                    ClientRequestTokenManager.CancelToken(cancelParams.Id);
                }

                return true;
            }
        }

        if (State != RunningState.Running)
        {
            return true;
        }

        return false;
    }

    public async Task Run()
    {
        try
        {
            while (State != RunningState.Exit)
            {
                var message = await Reader.ReadAsync();
                if (BaseHandle(message))
                {
                    continue;
                }

                Scheduler.Schedule(OnDispatch, message);
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }
}
