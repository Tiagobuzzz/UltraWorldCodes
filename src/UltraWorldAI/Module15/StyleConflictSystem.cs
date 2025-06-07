using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class AestheticFaction
{
    public string SchoolName = string.Empty;
    public string CoreSymbol = string.Empty; // "Caos visual", "Perfeição simétrica"
    public List<string> Opposes = new(); // Nomes de escolas rivais
    public string ArtisticPhilosophy = string.Empty;
}

public static class StyleConflictSystem
{
    public static List<AestheticFaction> Factions { get; } = new();

    public static void AddSchool(string name, string symbol, List<string> enemies, string philosophy)
    {
        Factions.Add(new AestheticFaction
        {
            SchoolName = name,
            CoreSymbol = symbol,
            Opposes = enemies,
            ArtisticPhilosophy = philosophy
        });

        Console.WriteLine($"\u2694\uFE0F Escola estética: {name} | Contra: {string.Join(", ", enemies)} | Filosofia: {philosophy}");
    }
}
