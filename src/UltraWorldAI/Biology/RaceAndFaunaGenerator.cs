using System;
using System.Collections.Generic;

namespace UltraWorldAI.Biology;

public class Creature
{
    public string Name { get; set; } = string.Empty;
    public string Diet { get; set; } = string.Empty;
    public string Biome { get; set; } = string.Empty;
    public string DNA { get; set; } = string.Empty;
    public List<string> Traits { get; set; } = new();
    public int AggressionLevel { get; set; }
}

public static class RaceAndFaunaGenerator
{
    public static List<Creature> Creatures { get; } = new();

    public static void Generate(int count, List<string> biomes)
    {
        string[] names = { "Dralt", "Virma", "Koak", "Surni", "Torex", "Grud" };
        string[] diets = { "Carn\u00EDvoro", "Herb\u00EDvoro", "Omn\u00EDvoro" };
        string[] traitsPool =
        {
            "Cegueira adaptativa",
            "Pele resistente",
            "Veneno",
            "Vis\u00E3o t\u00E9rmica",
            "Garras retr\u00E1teis"
        };

        var rand = new Random();
        for (int i = 0; i < count; i++)
        {
            string dna = $"G-{rand.Next(1000, 9999)}X{rand.Next(100, 999)}";
            var traits = new List<string> { traitsPool[rand.Next(traitsPool.Length)] };

            var creature = new Creature
            {
                Name = $"{names[rand.Next(names.Length)]}-{rand.Next(100)}",
                Diet = diets[rand.Next(diets.Length)],
                Biome = biomes[rand.Next(biomes.Count)],
                DNA = dna,
                Traits = traits,
                AggressionLevel = rand.Next(0, 100)
            };

            Creatures.Add(creature);
        }
    }

    public static string ListAll()
    {
        if (Creatures.Count == 0) return "Nenhuma criatura gerada.";
        return string.Join("\n\n", Creatures.ConvertAll(c =>
            $"\uD83E\uDDEC {c.Name} ({c.Diet})\nHabitat: {c.Biome} | DNA: {c.DNA}\nTra\u00E7os: {string.Join(", ", c.Traits)} | Agressividade: {c.AggressionLevel}"));
    }
}
