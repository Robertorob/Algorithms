
Console.WriteLine("Тот же поток, task успел завершиться, 1000_000_000 миллисекунд работало основной поток");
await Continuation.Run(1000_000_000);

Console.WriteLine("Другой поток, task не успел завершиться, 1000 миллисекунд работало основной поток");
await Continuation.Run(1000);
