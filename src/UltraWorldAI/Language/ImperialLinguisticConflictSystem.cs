using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class ImperialLanguageConflict
{
    public string RegionA { get; init; } = string.Empty;
    public string RegionB { get; init; } = string.Empty;
    public string Language { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
}

public static class ImperialLinguisticConflictSystem
{
    public static List<ImperialLanguageConflict> Conflicts { get; } = new();

    public static void DeclareConflict(string regionA, string regionB, string language, string reason)
    {
        Conflicts.Add(new ImperialLanguageConflict
        {
            RegionA = regionA,
            RegionB = regionB,
            Language = language,
            Reason = reason
        });

        Console.WriteLine($"\u2694\uFE0F Conflito lingu\u00edstico entre {regionA} e {regionB} sobre '{language}' \u2192 {reason}");
    }

    public static void PrintAllConflicts()
    {
        foreach (var c in Conflicts)
            Console.WriteLine($"\n{c.RegionA} x {c.RegionB} ({c.Language}) - {c.Reason}");
    }
}
