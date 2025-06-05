using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class RegionTopology
{
    public string RegionName { get; set; } = string.Empty;
    public string TerrainType { get; set; } = string.Empty;
    public int Altitude { get; set; }
    public bool HasRiverSource { get; set; }
    public bool HasCoast { get; set; }
}

public static class TopologyGenerator
{
    public static List<RegionTopology> Topologies { get; } = new();

    public static void Generate(List<WorldRegion> regions)
    {
        string[] types = { "Plan\u00EDcie", "Montanha", "Vale", "Delta", "Costa" };
        var rand = new Random();

        foreach (var region in regions)
        {
            Topologies.Add(new RegionTopology
            {
                RegionName = region.Name,
                TerrainType = types[rand.Next(types.Length)],
                Altitude = rand.Next(0, 4000),
                HasRiverSource = rand.NextDouble() > 0.5,
                HasCoast = region.Name.Contains("Luz") || rand.NextDouble() > 0.7
            });
        }
    }

    public static string ListAll()
    {
        return string.Join("\n\n", Topologies.ConvertAll(t =>
            $"\u26F0\uFE0F {t.RegionName} - {t.TerrainType}\nAltitude: {t.Altitude}m | Rio: {(t.HasRiverSource ? "Sim" : "N\u00E3o")} | Costa: {(t.HasCoast ? "Sim" : "N\u00E3o")}"));
    }
}
