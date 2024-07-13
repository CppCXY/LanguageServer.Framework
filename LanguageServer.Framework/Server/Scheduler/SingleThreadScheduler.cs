using System.Collections.Concurrent;

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

    public void Schedule(Func<Task> action)
    {
        _tasks.Add(() => action().Wait());
    }
}
