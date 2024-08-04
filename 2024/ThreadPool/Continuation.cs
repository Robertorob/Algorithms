/// <summary>
/// https://www.youtube.com/watch?v=il9gl8MH17s
/// </summary>
public static class Continuation
{
    /*
     * Здесь мы видимо, что после await код может выполниться в другом потоке.
     * 1. Если к моменту "await" task ещё не успел завершиться, то continuation PrintCurrentThreadId("5")
     * выполнится в другом потоке.
     * 2. Если к моменту "await" task успел завершиться, то continuation PrintCurrentThreadId("5")
     * выполнится в том же потоке.
     * Чтобы это проверить, ставим milliseconds для основного потока:
     * 1. 1000_000_000, тогда task УСПЕЕТ завершиться и continuation будет в том же потоке.
     * 2. 1000, тогда task НЕ_УСПЕЕТ завершиться и continuation будет в другом потоке.
     */
    public static async Task Run(int milliseconds)
    {
        PrintCurrentThreadId("1");

        var client = new HttpClient();

        PrintCurrentThreadId("2");

        var task = client.GetStringAsync("http://google.com");

        PrintCurrentThreadId("3");

        int k = 0;
        /*
         * Здесь основной поток может работать долго, тогда task успеет завершиться.
         */
        for (int i = 0; i < milliseconds; i++)
        {
            k++;
        }

        PrintCurrentThreadId("4");
        await task;
        PrintCurrentThreadId("5");
    }

    /// <summary>
    /// Печатает id текущего потока вместе с message.
    /// </summary>
    /// <param name="message"></param>
    public static void PrintCurrentThreadId(string message)
    {
        Console.WriteLine($"Message: {message}, thread id: {Thread.CurrentThread.ManagedThreadId}");
    }
}

