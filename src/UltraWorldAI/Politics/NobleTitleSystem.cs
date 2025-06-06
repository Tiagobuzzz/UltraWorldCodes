using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class NobleTitle
{
    public string Name { get; set; } = string.Empty;
    public string Holder { get; set; } = string.Empty;
    public string Rank { get; set; } = string.Empty; // "Barão", "Conde", "Duque", "Rei", etc.
    public string CrestSymbol { get; set; } = string.Empty;
    public string House { get; set; } = string.Empty;
}

public static class NobleTitleSystem
{
    public static List<NobleTitle> Titles { get; } = new();

    public static void GrantTitle(string name, string holder, string rank, string crest, string house)
    {
        Titles.Add(new NobleTitle
        {
            Name = name,
            Holder = holder,
            Rank = rank,
            CrestSymbol = crest,
            House = house
        });

        Console.WriteLine($"🛡️ {holder} recebeu o título de {rank} ({name}) com brasão '{crest}' da Casa {house}.");
    }

    public static void PrintTitles()
    {
        foreach (var t in Titles)
            Console.WriteLine($"\n👑 {t.Rank} {t.Holder} | Título: {t.Name} | Casa: {t.House} | Heráldica: {t.CrestSymbol}");
    }
}
