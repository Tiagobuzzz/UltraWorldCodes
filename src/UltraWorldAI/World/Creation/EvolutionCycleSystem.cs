using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class EvolutionaryStage
{
    public string Species { get; set; } = string.Empty;
    public int Generation { get; set; }
    public Dictionary<string, string> AdaptedTraits { get; set; } = new();
    public string EnvironmentalCause { get; set; } = string.Empty;
}

public static class EvolutionCycleSystem
{
    public static List<EvolutionaryStage> Stages { get; } = new();

    public static void RecordEvolution(string species, int generation, Dictionary<string, string> traits, string cause)
    {
        Stages.Add(new EvolutionaryStage
        {
            Species = species,
            Generation = generation,
            AdaptedTraits = traits,
            EnvironmentalCause = cause
        });

        Console.WriteLine($"\U0001f501 {species} evoluiu na geração {generation} por causa de {cause}");
        foreach (var t in traits)
            Console.WriteLine($"   - Novo traço: {t.Key} \u2192 {t.Value}");
    }

    public static void PrintEvolutions()
    {
        foreach (var e in Stages)
            Console.WriteLine($"\n\U0001f9ec {e.Species} | Geração {e.Generation} | Causa: {e.EnvironmentalCause} | Traços: {string.Join(", ", e.AdaptedTraits)}");
    }
}
