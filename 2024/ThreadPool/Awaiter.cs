using System.Runtime.CompilerServices;

public struct Awaiter(MyTask task) : INotifyCompletion
{
    public Awaiter GetAwaiter() => this;

    public bool IsCompleted => task.IsCompleted;

    public void OnCompleted(Action continuation) => task.ContinueWith(continuation);

    public void GetResult() => task.Wait();
}