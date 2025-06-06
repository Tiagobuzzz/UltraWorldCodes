using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class IdeologyConflict
{
    public string SchoolA { get; init; } = string.Empty;
    public string SchoolB { get; init; } = string.Empty;
    public string ConflictType { get; init; } = string.Empty;
    public int Year { get; init; }
}

public static class EconomicIdeologyConflictSystem
{
    public static List<IdeologyConflict> Conflicts { get; } = new();

    public static void DeclareConflict(string schoolA, string schoolB, string type, int year)
    {
        if (Conflicts.Any(c => c.SchoolA == schoolA && c.SchoolB == schoolB && c.ConflictType == type && c.Year == year))
            return;

        Conflicts.Add(new IdeologyConflict
        {
            SchoolA = schoolA,
            SchoolB = schoolB,
            ConflictType = type,
            Year = year
        });

        Console.WriteLine($"\u2694\ufe0f Conflito declarado entre {schoolA} e {schoolB} ({type}) – Ano {year}");
    }

    public static void PrintAllConflicts()
    {
        foreach (var c in Conflicts)
            Console.WriteLine($"\ud83d\udd25 {c.SchoolA} vs {c.SchoolB} | Tipo: {c.ConflictType} | Ano: {c.Year}");
    }
}
