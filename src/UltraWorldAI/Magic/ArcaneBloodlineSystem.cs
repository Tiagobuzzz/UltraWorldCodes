using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class Bloodline
{
    public string Name = string.Empty;
    public string Origin = string.Empty; // "Drag\u00E3o", "Deus Solar", "Abismo"
    public List<string> ArcaneTraits = new(); // "Sangue quente", "Toque de luz", etc.
    public int PurityLevel; // 0–100%
}

public static class ArcaneBloodlineSystem
{
    public static List<Bloodline> Bloodlines { get; } = new();

    public static void RegisterBloodline(string name, string origin, List<string> traits, int purity)
    {
        Bloodlines.Add(new Bloodline
        {
            Name = name,
            Origin = origin,
            ArcaneTraits = traits,
            PurityLevel = purity
        });

        Console.WriteLine($"\uD83E\uDDE2 Linhagem arcana: {name} | Origem: {origin} | Pureza: {purity}%");
    }

    public static void PrintBloodlines()
    {
        foreach (var b in Bloodlines)
            Console.WriteLine($"\n\uD83D\uDD2E {b.Name} | Origem: {b.Origin} | Pureza: {b.PurityLevel}% | Tra\u00E7os: {string.Join(", ", b.ArcaneTraits)}");
    }
}
