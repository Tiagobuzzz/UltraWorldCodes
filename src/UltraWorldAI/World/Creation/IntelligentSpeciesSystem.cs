using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class IntelligentSpecies
{
    public string Name { get; set; } = string.Empty;
    public string OriginBiome { get; set; } = string.Empty;
    public Dictionary<string, string> GeneticTraits { get; set; } = new();
    public string CultureSeed { get; set; } = string.Empty;
}

public static class IntelligentSpeciesSystem
{
    public static List<IntelligentSpecies> SpeciesList { get; } = new();

    public static void CreateSpecies(string name, string biome, Dictionary<string, string> traits, string cultureSeed)
    {
        SpeciesList.Add(new IntelligentSpecies
        {
            Name = name,
            OriginBiome = biome,
            GeneticTraits = traits,
            CultureSeed = cultureSeed
        });

        Console.WriteLine($"\U0001f9e0 Nova raça: {name} (Bioma: {biome}) | Cultura inicial: {cultureSeed}");
        foreach (var t in traits)
            Console.WriteLine($"   - Gene: {t.Key} = {t.Value}");
    }

    public static void PrintSpecies()
    {
        foreach (var s in SpeciesList)
            Console.WriteLine($"\n\U0001f9ec {s.Name} | Bioma: {s.OriginBiome} | Cultura: {s.CultureSeed} | Traits: {string.Join(", ", s.GeneticTraits)}");
    }
}
