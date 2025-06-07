using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class DivineSource
{
    public string DeityName = string.Empty;
    public string Domain = string.Empty; // "Chama do Julgamento", "Verdade", "Tempo"
    public string Revelation = string.Empty; // "Promete a chegada do fogo final", etc.
}

public static class DivineMagicSystem
{
    public static List<DivineSource> Deities { get; } = new();

    public static void AddDeity(string name, string domain, string revelation)
    {
        Deities.Add(new DivineSource
        {
            DeityName = name,
            Domain = domain,
            Revelation = revelation
        });

        Console.WriteLine($"\uD83D\uDD25 Divindade: {name} | Dom\u00EDnio: {domain} | Revela\u00E7\u00E3o: {revelation}");
    }

    public static void PrintDeities()
    {
        foreach (var d in Deities)
            Console.WriteLine($"\n\uD83D\uDD6F\uFE0F {d.DeityName} | Dom\u00EDnio: {d.Domain} | Revela\u00E7\u00E3o: {d.Revelation}");
    }
}
