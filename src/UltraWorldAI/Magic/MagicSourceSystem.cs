using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class MagicSource
{
    public string Name = string.Empty;
    public string Type = string.Empty; // "Elemental", "Mental", "Temporal", "Espiritual", "Geológica", etc.
    public string Origin = string.Empty; // "Nexo Planetário", "Pacto Ancestral", "Cristal Caído", etc.
    public bool IsStable;
}

public static class MagicSourceSystem
{
    public static List<MagicSource> Sources { get; } = new();

    public static void RegisterSource(string name, string type, string origin, bool stable)
    {
        Sources.Add(new MagicSource
        {
            Name = name,
            Type = type,
            Origin = origin,
            IsStable = stable
        });

        Console.WriteLine($"\uD83D\uDD2E Fonte mágica: {name} | Tipo: {type} | Origem: {origin} | Estável: {stable}");
    }

    public static void PrintSources()
    {
        foreach (var s in Sources)
            Console.WriteLine($"\n\u2728 {s.Name} | Tipo: {s.Type} | Origem: {s.Origin} | Estável: {s.IsStable}");
    }
}
