namespace UltraWorldAI;

internal static class RandomSingleton
{
    private static readonly System.Random _shared = new();
    public static System.Random Shared => _shared;
}
