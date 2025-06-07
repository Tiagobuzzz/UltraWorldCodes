using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class ArchivistFervor
{
    public string Name = string.Empty;
    public string Document = string.Empty;
    public string Outcome = string.Empty; // "Fanático" ou "Mártir"
}

public static class ArchivistFervorSystem
{
    public static List<ArchivistFervor> Records { get; } = new();

    public static void GuardDocument(string name, string document, string outcome)
    {
        Records.Add(new ArchivistFervor
        {
            Name = name,
            Document = document,
            Outcome = outcome
        });

        Console.WriteLine($"\uD83D\uDD6F️ Arquivista {name} tornou-se {outcome} ao proteger '{document}'");
    }
}
