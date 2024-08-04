Console.WriteLine($"Environment processor count: {Environment.ProcessorCount}");

//Console.WriteLine();

//await Continuation.Run();

Console.WriteLine();

await MyThreadPool.RunExperiment();
