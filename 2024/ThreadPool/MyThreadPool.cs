using System.Collections.Concurrent;

/// <summary>
/// Stephen Toub.
/// Video:
/// https://www.youtube.com/watch?v=R-z2Hv-7nxk
/// Source code:
/// https://gist.github.com/jamesmontemagno/12992547430b85723e997a312f13ddf7
/// </summary>
public static class MyThreadPool
{
    /// <summary>
    /// Stephen Toub quote:
    /// Concurrent Queue.
    /// When I wanna take comething out, I will block waiting to take out the thing
    /// if it's empty.
    /// Когда я хочу вытащить задачу, я буду выполнять блокирующее ожидание, если очередь пуста.
    /// Это то, что мне нужно: я хочу чтобы мой ThreadPool пытался взять задачу из этой очереди, и если
    /// задач нет, чтобы ThreadPool ждал.
    /// </summary>
    private static readonly BlockingCollection<(Action, ExecutionContext?)> s_workItems = new();

    public static void QueueUserWorkItem(Action action) => s_workItems.Add((action, ExecutionContext.Capture()));

    public const int LOOPS_COUNT = 30;
    public const int DELAY_IN_LOOP = 1000;
    public static readonly int DelayAfterAllLoops = LOOPS_COUNT * DELAY_IN_LOOP / Environment.ProcessorCount;

    static MyThreadPool()
    {
        /*
         * В настоящей реализации нет фиксированного количества потоков.
         * Много внимания уделяется управлению количеством потоков в пуле в real-time, чтобы
         * обеспечить максимальную производительность.
         */
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            var thread = new Thread(() =>
            {
                while (true)
                {
                    (Action workItem, ExecutionContext? context) = s_workItems.Take();
                    
                    if (context is null)
                    {
                        workItem();
                    }
                    else
                    {
                        /* 
                         * ((Action)state!).Invoke() the same as ((Action)state!)()
                         * Run "state => ((Action)state!).Invoke()"
                         * in "context"
                         * where "state" is "workItem"
                        */
                        ExecutionContext.Run(context, state => ((Action)state!).Invoke(), workItem);
                    }
                }
            });

            // Так мы показываем, что главный процесс не должен ждать окончания работы этих потоков.
            thread.IsBackground = true;

            thread.Start();
        }
    }

    /// <summary>
    /// Закидываем в MyThreadPool 100 задачек на вывод числа.
    /// </summary>
    private static void RunMyThreadPool()
    {
        AsyncLocal<int> myValue = new();
        for (int i = 0; i < LOOPS_COUNT; i++)
        {
            myValue.Value = i;
            int capturedValue = i;
            MyThreadPool.QueueUserWorkItem(() =>
            {
                Console.WriteLine($"MyThreadPool -> simple int: {capturedValue}");
                Console.WriteLine($"MyThreadPool -> AsyncLocal: {myValue.Value}");
                Thread.Sleep(DELAY_IN_LOOP);
            });
        }
    }

    /// <summary>
    /// Закидываем в ThreadPool 100 задачек на вывод числа.
    /// </summary>
    private static void RunThreadPool()
    {
        /*
         * Stored in the ExecutionContext and flow through async calls.
         */
        AsyncLocal<int> myValue = new();
        for (int i = 0; i < LOOPS_COUNT; i++)
        {
            myValue.Value = i;
            int capturedValue = i;

            ThreadPool.QueueUserWorkItem(delegate
            {
                Console.WriteLine($"ThreadPool -> simple int: {capturedValue}");
                Console.WriteLine($"ThreadPool -> AsyncLocal: {myValue.Value}");
                Thread.Sleep(DELAY_IN_LOOP);
            });
        }
    }

    public static async Task RunExperiment()
    {
        //RunMyThreadPool();
        //await Task.Delay(DelayAfterAllLoops);
        //RunThreadPool();
        //await Task.Delay(DelayAfterAllLoops);
        //UseTaskRun();
        //await Task.Delay(DelayAfterAllLoops);
        // Console.ReadKey();

        // UseTaskWhenAll();

        // UseTaskDelay();

        //UseChainedTaskDelay();

        // UseChainedTaskDelay2();

        UseIterator();

    }

    /// <summary>
    /// Используем MyTask.Run().
    /// </summary>
    private static void UseTaskRun()
    {
        List<MyTask> tasks = new();

        AsyncLocal<int> myValue = new();
        for (int i = 0; i < LOOPS_COUNT; i++)
        {
            myValue.Value = i;
            tasks.Add(MyTask.Run(delegate
            {
                Console.WriteLine($"MyTask.Run -> AsyncLocal: {myValue.Value}");
                Thread.Sleep(DELAY_IN_LOOP);
            }));
        }

        /*
         * Хотелось бы использовать Task.WhenAll(Task[])
         */
        foreach (MyTask task in tasks)
        {
            task.Wait();
        }
    }

    /// <summary>
    /// Используем MyTask.Run().
    /// </summary>
    private static void UseTaskWhenAll()
    {
        List<MyTask> tasks = new();

        AsyncLocal<int> myValue = new();
        for (int i = 0; i < LOOPS_COUNT; i++)
        {
            myValue.Value = i;
            tasks.Add(MyTask.Run(delegate
            {
                Console.WriteLine($"MyTask.Run -> AsyncLocal: {myValue.Value}");
                Thread.Sleep(DELAY_IN_LOOP);
            }));
        }

        MyTask.WhenAll(tasks).Wait();
    }

    /// <summary>
    /// Используем MyTask.Delay().
    /// </summary>
    private static void UseTaskDelay()
    {
        Console.WriteLine("Hello, ");
        MyTask.Delay(2000).ContinueWith(delegate
        {
            Console.WriteLine("World!");
        }).Wait();
    }

    /// <summary>
    /// Используем цепочку делегатов.
    /// </summary>
    private static void UseChainedTaskDelay()
    {
        Console.WriteLine("Hello, ");
        MyTask.Delay(1000).ContinueWith(delegate
        {
            Console.WriteLine("World!");
            return MyTask.Delay(1000).ContinueWith(delegate
            {
                Console.WriteLine("And Robert!");
                return MyTask.Delay(1000).ContinueWith(delegate
                {
                    Console.WriteLine("How are you?");
                });
            });
        }).Wait();
    }

    /// <summary>
    /// Используем цепочку делегатов.
    /// </summary>
    private static void UseChainedTaskDelay2()
    {
        Console.WriteLine("Hello, ");
        MyTask.Delay(1000).ContinueWith(delegate
        {
            Console.WriteLine("World!");
            return MyTask.Delay(1000);
        }).ContinueWith(delegate
        {
            Console.WriteLine("How are you");
        }).Wait();
    }

    /// <summary>
    /// итератор, yield.
    /// </summary>
    private static void UseIterator()
    {
        static IEnumerable<MyTask> PrintAsync()
        {
            for (int i = 0; ; i++)
            {
                yield return MyTask.Delay(1000);
                Console.WriteLine(i);
            }
        }

        MyTask.Iterate(PrintAsync()).Wait();
    }
}

