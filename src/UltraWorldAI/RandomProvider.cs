using System;
namespace UltraWorldAI;

public static class RandomProvider
{
    private static readonly Random _global = new();
    private static readonly object _lock = new();

    public static int Next(int min, int max)
    {
        lock (_lock)
        {
            return _global.Next(min, max);
        }
    }

    public static int Next(int max)
    {
        lock (_lock)
        {
            return _global.Next(max);
        }
    }

    public static double NextDouble()
    {
        lock (_lock)
        {
            return _global.NextDouble();
        }
    }
}
