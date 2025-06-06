using System;

namespace UltraWorldAI.Game;

/// <summary>
/// Utility for random chance based events.
/// </summary>
public static class ChanceEventSystem
{
    private static Random _rand = new();

    public static void SetSeed(int seed) => _rand = new Random(seed);

    public static int RollDice(int sides)
    {
        return _rand.Next(1, sides + 1);
    }

    public static bool TriggerEvent(string name, int chancePercent)
    {
        return _rand.Next(0, 100) < chancePercent;
    }
}
