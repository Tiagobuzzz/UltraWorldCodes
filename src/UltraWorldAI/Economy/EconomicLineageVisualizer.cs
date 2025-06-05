using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public static class EconomicLineageVisualizer
{
    public static void PrintTree(string rootCulture, List<EconomicHeirloom> history)
    {
        Console.WriteLine($"\uD83C\uDF33 Linhagem Econ\u00f4mica de {rootCulture}:\n");
        Traverse(rootCulture, history, 0);
    }

    private static void Traverse(string culture, List<EconomicHeirloom> history, int indent)
    {
        var children = history
            .Where(h => h.OriginCulture == culture)
            .OrderBy(h => h.Year)
            .ToList();

        foreach (var child in children)
        {
            string line = new(' ', indent * 2);
            line += $"\u2192 {child.InheritorCulture} ({child.MutationType}) {child.OriginalModel} \u2192 {child.NewModel} (Ano {child.Year})";
            Console.WriteLine(line);
            Traverse(child.InheritorCulture, history, indent + 1);
        }
    }
}
