using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class CaveSystem
{
    public string Name { get; set; } = string.Empty;
    public string LocatedInRegion { get; set; } = string.Empty;
    public int DepthLevel { get; set; }
    public bool IsConnectedToSurface { get; set; }
    public List<string> Creatures { get; set; } = new();
    public string Feature { get; set; } = string.Empty;
}

public static class WorldCaveSystem
{
    public static List<CaveSystem> Caves { get; } = new();

    public static void GenerateCaves(List<WorldRegion> regions, int maxCaves)
    {
        var rand = new Random();
        string[] features = { "Lago Subterrâneo", "Cristais Vivos", "Rede de Túneis", "Ruínas Antigas" };
        string[] creatures = { "Vermes de Sangue", "Sapos Cegos", "Seres de Névoa", "Répteis Trogloditas" };

        for (int i = 0; i < maxCaves; i++)
        {
            var region = regions[rand.Next(regions.Count)];
            var cave = new CaveSystem
            {
                Name = "Caverna de " + region.Name,
                LocatedInRegion = region.Name,
                DepthLevel = rand.Next(1, 10),
                IsConnectedToSurface = rand.NextDouble() > 0.4,
                Creatures = new List<string> { creatures[rand.Next(creatures.Length)] },
                Feature = features[rand.Next(features.Length)]
            };
            Caves.Add(cave);
        }
    }

    public static string DescribeAll()
    {
        if (Caves.Count == 0) return "Nenhuma caverna foi criada.";
        return string.Join("\n\n", Caves.ConvertAll(c =>
            $"\uD83D\uDD73️ {c.Name} em {c.LocatedInRegion}\nProfundidade: {c.DepthLevel} | Acesso: {(c.IsConnectedToSurface ? "Sim" : "Não")}\nCriaturas: {string.Join(", ", c.Creatures)}\nElemento: {c.Feature}"));
    }
}
