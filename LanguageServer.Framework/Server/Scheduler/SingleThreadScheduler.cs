using System.Collections.Concurrent;
using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;

namespace EmmyLua.LanguageServer.Framework.Server.Scheduler;

public class SingleThreadScheduler : IScheduler
{
    private readonly Thread _workerThread;
    private readonly BlockingCollection<Action> _tasks = new BlockingCollection<Action>();

    public SingleThreadScheduler()
    {
        _workerThread = new Thread(() =>
        {
            foreach (var task in _tasks.GetConsumingEnumerable())
            {
                try
                {
                    task();
                }
                catch
                {
                    // Handle exceptions or log errors
                }
            }
        })
        {
            IsBackground = true
        };
        _workerThread.Start();
    }

    public void Schedule(Func<Message, Task> action, Message message)
    {
        _tasks.Add(() => action(message).Wait());
    }
}
