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

public class LanguageServer : LSPCommunicationBase
{
    private enum RunningState
    {
        Running,
        Shutdown,
        Exit
    }

    private int _state = (int)RunningState.Running;

    private RunningState State
    {
        get => (RunningState)Interlocked.CompareExchange(ref _state, 0, 0);
        set => Interlocked.Exchange(ref _state, (int)value);
    }

    public ClientProxy Client { get; }

    public LanguageServerOptions Options { get; }

    private Timer? _metricsTimer;

    public LanguageServer(Stream input, Stream output, LanguageServerOptions? options = null) : base(input, output)
    {
        Options = options ?? LanguageServerOptions.Default;
        Client = new ClientProxy(this);
        AddHandler(new InitializeHandler(this));

        // Initialize performance metrics collector based on options
        if (Options.EnablePerformanceTracing)
        {
            MetricsCollector = new Metrics.DefaultPerformanceMetricsCollector();

            // Start timer if periodic print interval is set
            if (Options.PerformanceMetricsPrintInterval.HasValue)
            {
                _metricsTimer = new Timer(
                    _ => PrintMetrics(),
                    null,
                    Options.PerformanceMetricsPrintInterval.Value,
                    Options.PerformanceMetricsPrintInterval.Value
                );
            }
        }
    }

    public static LanguageServer From(Stream input, Stream output, LanguageServerOptions? options = null)
    {
        return new LanguageServer(input, output, options);
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

    protected override bool BaseHandle(Message message)
    {
        if (message is RequestMessage requestMessage)
        {
            if (requestMessage.Method == "shutdown")
            {
                State = RunningState.Shutdown;

                // Print final performance metrics on shutdown
                if (Options.EnablePerformanceTracing)
                {
                    Console.Error.WriteLine("\n=== Final Performance Metrics (on shutdown) ===");
                    PrintMetrics();
                }

                ShutdownEventDelegate?.Invoke();
                Writer.WriteShutdownResponse(requestMessage.Id);
                return true;
            }
        }
        else if (message is NotificationMessage notification)
        {
            if (notification.Method == "exit")
            {
                State = RunningState.Exit;
                // Environment.Exit(State == RunningState.Shutdown ? 0 : 1);
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _metricsTimer?.Dispose();
        }

        base.Dispose(disposing);
    }
}
