using System;

namespace UltraWorldAI.World;

/// <summary>
/// Tracks the level of nuclear catastrophe risk across the world.
/// </summary>
public static class NuclearRiskSystem
{
    private static readonly Random _rng = new();
    private static double _riskLevel = 0.5;

    public static double GetRiskLevel() => _riskLevel;

    public static void Tick()
    {
        var change = (_rng.NextDouble() - 0.5) * 0.05;
        if (change == 0)
            change = 0.01 * (_rng.Next(0, 2) == 0 ? -1 : 1);
        _riskLevel = Math.Clamp(_riskLevel + change, 0.0, 1.0);
    }
}
