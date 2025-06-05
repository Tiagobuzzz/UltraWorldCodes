using System;
using System.Collections.Generic;
using UltraWorldAI.Biology;

namespace UltraWorldAI.Civilization;

public static class RaceGeneticCompatibility
{
    private static readonly Dictionary<(string, string), bool> CompatibilityMap = new()
    {
        { ("Humanos", "Elfos"), true },
        { ("Humanos", "Tieflings"), true },
        { ("Elfos", "Fae"), true },
        { ("Anões", "Gigantes"), false },
        { ("Insectoides", "qualquer"), false },
        { ("Atlantes", "Humanos"), true },
        { ("Atlantes", "Elfos"), false },
        { ("Tieflings", "Fae"), true }
    };

    public static bool CanCross(string raceA, string raceB)
    {
        return CompatibilityMap.ContainsKey((raceA, raceB)) ||
               CompatibilityMap.ContainsKey((raceB, raceA)) ||
               CompatibilityMap.ContainsKey((raceA, "qualquer")) ||
               CompatibilityMap.ContainsKey(("qualquer", raceB));
    }

    public static Genome CreateHybridGenome(Genome g1, Genome g2)
    {
        if (g1.Genes.Count != g2.Genes.Count)
            throw new Exception("Genomas incompatíveis em tamanho");

        var hybrid = new Genome();
        var rand = new Random();

        for (int i = 0; i < g1.Genes.Count; i++)
        {
            string alleleA = rand.NextDouble() > 0.5 ? g1.Genes[i].AlleleA : g1.Genes[i].AlleleB;
            string alleleB = rand.NextDouble() > 0.5 ? g2.Genes[i].AlleleA : g2.Genes[i].AlleleB;

            hybrid.Genes.Add(new Gene
            {
                Trait = g1.Genes[i].Trait,
                AlleleA = alleleA,
                AlleleB = alleleB,
                ExpressionType = g1.Genes[i].ExpressionType
            });
        }

        GeneticMutation.Mutate(hybrid);
        return hybrid;
    }
}
