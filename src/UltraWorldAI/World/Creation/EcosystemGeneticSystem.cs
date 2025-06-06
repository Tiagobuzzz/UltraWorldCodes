using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class Genome
{
    public string Species { get; set; } = string.Empty;
    public Dictionary<string, string> Traits { get; set; } = new();
}

public class Creature
{
    public string Name { get; set; } = string.Empty;
    public Genome DNA { get; set; } = new();
    public string Biome { get; set; } = string.Empty;
}

public static class EcosystemGeneticSystem
{
    public static List<Creature> Creatures { get; } = new();

    public static void SpawnCreature(string name, string biome, Dictionary<string, string> traits)
    {
        Genome genome = new() { Species = name, Traits = traits };
        Creatures.Add(new Creature { Name = name, Biome = biome, DNA = genome });

        Console.WriteLine($"\uD83E\uDDEC Criatura criada: {name} | Bioma: {biome}");
        foreach (var t in traits)
            Console.WriteLine($"   - {t.Key}: {t.Value}");
    }

    public static void PrintCreatures()
    {
        foreach (var c in Creatures)
            Console.WriteLine($"\n\uD83E\uDD8E {c.Name} | Bioma: {c.Biome} | DNA: {string.Join(", ", c.DNA.Traits)}");
    }
}

