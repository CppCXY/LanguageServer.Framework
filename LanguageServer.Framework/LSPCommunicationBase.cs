using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol;
using EmmyLua.LanguageServer.Framework.Protocol.Capabilities.Client.ClientCapabilities;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;
using EmmyLua.LanguageServer.Framework.Protocol.Message;
using EmmyLua.LanguageServer.Framework.Protocol.Message.Initialize;
using EmmyLua.LanguageServer.Framework.Server;
using EmmyLua.LanguageServer.Framework.Server.Handler;
using EmmyLua.LanguageServer.Framework.Server.JsonProtocol;
using EmmyLua.LanguageServer.Framework.Server.RequestManager;
using EmmyLua.LanguageServer.Framework.Server.Scheduler;

namespace EmmyLua.LanguageServer.Framework;

public abstract class LSPCommunicationBase
{
    public JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        TypeInfoResolver = JsonProtocolContext.Default,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    protected JsonProtocolReader Reader { get; }

    protected JsonProtocolWriter Writer { get; }


    protected IScheduler Scheduler { get; set; } = new SingleThreadScheduler();

    protected ClientRequestTokenManager ClientRequestTokenManager { get; } = new();
    protected ServerRequestManager ServerRequestManager { get; } = new();

    // ReSharper disable once CollectionNeverQueried.Local
    public List<IJsonHandler> Handlers { get; } = new();

    protected Dictionary<string, Func<RequestMessage, CancellationToken, Task<JsonDocument?>>>
        RequestHandlers { get; } =
        new();

    protected Dictionary<string, Func<NotificationMessage, CancellationToken, Task>> NotificationHandlers { get; } =
        new();

    public ClientCapabilities ClientCapabilities { get; set; } = null!;

    protected LSPCommunicationBase(Stream input, Stream output)
    {
        Reader = new JsonProtocolReader(input, JsonSerializerOptions);
        Writer = new JsonProtocolWriter(output, JsonSerializerOptions);
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

    public LSPCommunicationBase AddHandler(IJsonHandler handler)
    {
        Handlers.Add(handler);
        handler.RegisterHandler(this);
        return this;
    }

    public virtual Task SendNotification(NotificationMessage notification)
    {
        Writer.WriteNotification(notification);
        return Task.CompletedTask;
    }

    public virtual async Task<JsonDocument?> SendRequest(string method, JsonDocument? @param, CancellationToken token)
    {
        var request = ServerRequestManager.MakeRequest(method, @param);
        Writer.WriteRequest(request);
        return await ServerRequestManager.WaitResponse(request.Id, token).ConfigureAwait(false);
    }

    public virtual Task SendRequestNoWait(string method, JsonDocument? @param)
    {
        var request = ServerRequestManager.MakeRequest(method, @param);
        Writer.WriteRequest(request);
        return Task.CompletedTask;
    }

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

    protected virtual bool BaseHandle(Message message)
    {
        return false;
    }

    public Task Run()
    {
        _mutexForExitTokenSource.WaitOne();
        if (ExitTokenSource is not null)
            throw new InvalidOperationException("Already running.");
        ExitTokenSource = new CancellationTokenSource();
        var task = Task.Run(async () =>
        {
            try
            {
                while (ExitTokenSource.IsCancellationRequested is false)
                {
                    var message = await Reader.ReadAsync(ExitTokenSource.Token);
                    if (BaseHandle(message))
                    {
                        continue;
                    }

                    Scheduler.Schedule(OnDispatch, message);
                }
            }
            catch (OperationCanceledException)
            {
                await Console.Error.WriteLineAsync("LSPCommunication exited");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            finally
            {
                ExitTokenSource.Dispose();
                ExitTokenSource = null;
            }
        });
        _mutexForExitTokenSource.ReleaseMutex();
        return task;
    }

    protected CancellationTokenSource? ExitTokenSource { get; private set; }
    private readonly Mutex _mutexForExitTokenSource = new();

    public void Exit()
    {
        _mutexForExitTokenSource.WaitOne();
        if (ExitTokenSource is null)
            throw new InvalidOperationException("Run() must be called before exit");
        ExitTokenSource!.Cancel();
        _mutexForExitTokenSource.ReleaseMutex();
    }
}
