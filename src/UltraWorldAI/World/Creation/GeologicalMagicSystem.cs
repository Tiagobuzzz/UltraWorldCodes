using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class Caverna
{
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public bool IsMagical { get; set; }
    public string ElementalEssence { get; set; } = string.Empty;
}

public static class GeologicalMagicSystem
{
    public static List<Caverna> Cavernas { get; } = new();

    public static void AddCaverna(string name, string region, bool magical, string essence)
    {
        Cavernas.Add(new Caverna
        {
            Name = name,
            Region = region,
            IsMagical = magical,
            ElementalEssence = essence
        });

        Console.WriteLine(magical
            ? $"\U0001f30c Caverna mágica descoberta: {name} ({essence}) em {region}"
            : $"\U0001f573️ Caverna natural: {name} em {region}");
    }

    public static void PrintCavernas()
    {
        foreach (var c in Cavernas)
            Console.WriteLine($"\n\U0001f3de️ {c.Name} | Região: {c.Region} | Mágica: {c.IsMagical} | Essência: {c.ElementalEssence}");
    }
}
