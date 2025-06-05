using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class BorderSegment
{
    public string RegionA { get; set; } = string.Empty;
    public string RegionB { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public float Fluidity { get; set; }
}

public static class OrganicBorderSystem
{
    public static List<BorderSegment> Borders { get; } = new();

    public static void GenerateBorders(List<WorldRegion> regions)
    {
        var rand = new Random();
        for (int i = 0; i < regions.Count - 1; i++)
        {
            var border = new BorderSegment
            {
                RegionA = regions[i].Name,
                RegionB = regions[i + 1].Name,
                Type = rand.NextDouble() > 0.5 ? "Zona de Transição" : "Rio",
                Fluidity = (float)Math.Round(rand.NextDouble(), 2)
            };
            Borders.Add(border);
        }
    }

    public static string DescribeAll()
    {
        if (Borders.Count == 0) return "Nenhuma fronteira gerada.";
        return string.Join("\n\n", Borders.ConvertAll(b =>
            $"\uD83D\uDDFA {b.RegionA} ↔ {b.RegionB}\nTipo: {b.Type} | Fluidez: {b.Fluidity * 100}%"));
    }
}
