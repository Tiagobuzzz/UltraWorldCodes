using System.Collections.Generic;

namespace UltraWorldAI.World.Biomes;

/// <summary>
/// Stores habitat/biome information per region.
/// </summary>
public static class HabitatSystem
{
    private static readonly Dictionary<string, string> _regionBiomes = new();

    public static void SetBiome(string region, string biome)
    {
        _regionBiomes[region] = biome;
    }

    public static string GetBiome(string region)
    {
        return _regionBiomes.TryGetValue(region, out var b) ? b : "Desconhecido";
    }
}
