using System;
using System.Collections.Generic;

namespace UltraWorldAI;

public class CulturalLinhagem
{
    public string Culture = string.Empty;
    public string MutationInherited = string.Empty;
    public string Ritual = string.Empty;
    public int Generations;
}

public static class CulturalLineageSystem
{
    public static List<CulturalLinhagem> Lineages { get; } = new();

    public static void RecordLinhagem(string culture, string mutation, string ritual)
    {
        var lin = new CulturalLinhagem
        {
            Culture = culture,
            MutationInherited = mutation,
            Ritual = ritual,
            Generations = 1
        };

        Lineages.Add(lin);
        Console.WriteLine($"\uD83D\uDD01 Linhagem cultural criada: {culture} \u2192 Muta\u00e7\u00e3o: {mutation} (via ritual '{ritual}')");
    }

    public static void AdvanceGeneration(string culture)
    {
        foreach (var l in Lineages)
        {
            if (l.Culture == culture)
            {
                l.Generations++;
                Console.WriteLine($"\uD83D\uDCDC {culture} preservou muta\u00e7\u00e3o '{l.MutationInherited}' por {l.Generations} gera\u00e7\u00f5es.");
            }
        }
    }

    public static void Reset() => Lineages.Clear();
}
