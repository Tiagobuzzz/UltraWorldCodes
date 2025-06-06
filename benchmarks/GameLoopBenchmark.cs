using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using UltraWorldAI;
using UltraWorldAI.Game;

[MemoryDiagnoser]
public class GameLoopBenchmark
{
    private GameLoop _loop = null!;

    [GlobalSetup]
    public void Setup()
    {
        IA.Initialize();
        _loop = new GameLoop(10, 10);
        _loop.AddPerson(new Person("Alice"), 1, 1);
        _loop.AddPerson(new Person("Bob"), 2, 2);
    }

    [Benchmark]
    public void RunLoop()
    {
        _loop.Run(5);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<GameLoopBenchmark>();
    }
}
