using System.Runtime.ExceptionServices;

/// <summary>
/// Stephen Toub.
/// Video:
/// https://www.youtube.com/watch?v=R-z2Hv-7nxk
/// Source code:
/// https://gist.github.com/jamesmontemagno/12992547430b85723e997a312f13ddf7
/// </summary>
public class MyTask
{
    private bool _completed;
    private Exception? _exception;
    private Action? _continuation;
    private ExecutionContext? _context;

    public bool IsCompleted
    {
        get
        {
            /*
             * Что плохого в lock(this) ?
             * Этого никогда нельзя делать.
             * Потому что лок обжект должен быть приватным. А в этом случае,
             * получается, что лок становится публичным, так как ссылку на объект задачи может иметь кто угодно.
             * Здесь мы просто знаем, что никто кроме тебя не будет иметь ссылку на этот объект.
             * Но не объяснено, почему никто кроме нас не будет иметь ссылку.
             */
            lock (this)
            {
                return _completed; 
            }
        }
    }

    /// <summary>
    /// Пометить задачу, как выполненную.
    /// В реальном коде этот метод находится в TaskCompletionSource.
    /// </summary>
    public void SetResult() => Complete(null);

    /// <summary>
    /// Пометить задачу, как выполненную.
    /// В реальном коде этот метод находится в TaskCompletionSource.
    /// </summary>
    public void SetException(Exception ex) => Complete(ex);

    /// <summary>
    /// Завершаем задачу либо с ошибкой, либо без.
    /// </summary>
    /// <param name="exception"></param>
    public void Complete(Exception? exception)
    {
        lock (this)
        {
            if (_completed) 
                throw new InvalidOperationException("Нельзя завершать задачу, которая уже завершилась.");

            _completed = true;
            _exception = exception;

            if (_continuation is not null)
            {
                MyThreadPool.QueueUserWorkItem(delegate
                {
                    if (_context is null)
                    {
                        _continuation();
                    }
                    else
                    {
                        ExecutionContext.Run(_context, state => ((Action)state!).Invoke(), _continuation);
                    }
                });
            }
        }
    }

    /// <summary>
    /// Ожидает задачу, присоединяется к ней (wait, join).
    /// Блокировка потока, синхронное ожидание завершения.
    /// </summary>
    public void Wait()
    {
        ManualResetEventSlim? mres = null;

        lock (this)
        {
            if (!_completed)
            {
                mres = new ManualResetEventSlim();
                ContinueWith(mres.Set);
            }
        }

        mres?.Wait();

        if (_exception is not null)
        {
            // Позволяет кинуть эксепшн и аппендить стек трейс, а не обнулять его.
            ExceptionDispatchInfo.Throw(_exception);
        }
    }

    public MyTask ContinueWith(Action action)
    {
        MyTask task = new();
        Action callback = () =>
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                task.SetException(e);
                return;
            }

            task.SetResult();
        };

        lock (this)
        {
            if (_completed)
            {
                /*
                 * Если задача уже завершена, то continuation можно продолжить в том же потоке.
                 * Это иллюстрируется в файле "Continuation.cs". Но тут по-другому, необходимо разобраться.
                 */
                MyThreadPool.QueueUserWorkItem(callback);
            }
            else
            {
                _continuation = callback;
                _context = ExecutionContext.Capture();
            }
        }

        return task;
    }

    public static MyTask Run(Action action)
    {
        MyTask task = new();

        MyThreadPool.QueueUserWorkItem(() =>
        {
            try
            {
                action();
            }
            catch (Exception exc)
            {
                task.SetException(exc);
                return;
            }
               
            task.SetResult();
        });

        return task;
    }

    public static MyTask WhenAll(List<MyTask> tasks)
    {
        MyTask resultTask = new();

        if (tasks.Count == 0)
        {
            resultTask.SetResult();
        }
        else
        {
            int remainingTasksCount = tasks.Count;

            Action continuation = () =>
            {
                /*
                 * Почему мы используем здесь Interlocked?
                 * I have no idea what these tasks are doing. They might all be completing at the
                 * same time or not. And if they complete at approximately the same time, two different
                 * threads might try decrement this value without any synchronization.
                 * 
                 * Это легковесный вариант блокирования кода, он является lock-free.
                 */
                if (Interlocked.Decrement(ref remainingTasksCount) == 0)
                {
                    // TODO: exceptions
                    resultTask.SetResult();
                }
            };

            foreach (var task in tasks)
            {
                task.ContinueWith(continuation);
            }
        }

        return resultTask;
    }

    public static MyTask Delay(int timeout)
    {
        MyTask task = new();
        new Timer(_ => task.SetResult()).Change(timeout, -1);
        return task;
    }
}
