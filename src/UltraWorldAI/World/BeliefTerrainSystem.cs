using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public static class BeliefTerrainSystem
{
    private static readonly Dictionary<string, string> _regions = new();

    public static void AlterRegion(string region, string belief)
    {
        _regions[region] = belief;
        Console.WriteLine($"\uD83C\uDF0E A regi\u00e3o de {region} foi alterada pela cren\u00e7a '{belief}'.");
    }

    public static string? GetRegionBelief(string region)
        => _regions.TryGetValue(region, out var b) ? b : null;

    public static void Reset() => _regions.Clear();
}
