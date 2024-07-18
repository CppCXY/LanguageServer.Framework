using EmmyLua.LanguageServer.Framework.Protocol.JsonRpc;

namespace EmmyLua.LanguageServer.Framework.Server.Scheduler;

public class SimpleMultiThreadScheduler : IScheduler
{
    public void Schedule(Func<Message, Task> action, Message message)
    {
        Task.Run(() => action(message));
    }
}
