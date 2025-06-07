using System;
using System.Collections.Generic;

namespace UltraWorldAI.Doctrine;

public class DoctrineNarrativeConflict
{
    public string Kingdom { get; set; } = string.Empty;
    public string OfficialDoctrine { get; set; } = string.Empty;
    public string PopularVersion { get; set; } = string.Empty;
    public int PopularSupport { get; set; }
    public bool RegimeChanged { get; set; }
}

public static class DoctrineNarrativeConflictSystem
{
    public static List<DoctrineNarrativeConflict> Conflicts { get; } = new();

    public static void AddConflict(string kingdom, string official, string popular, int support)
    {
        Conflicts.Add(new DoctrineNarrativeConflict
        {
            Kingdom = kingdom,
            OfficialDoctrine = official,
            PopularVersion = popular,
            PopularSupport = support,
            RegimeChanged = false
        });

        Console.WriteLine($"\uD83D\uDD04 Conflito doutrin\u00e1rio iniciado em {kingdom} (apoio popular: {support}% )");
    }

    public static void Escalate(string kingdom, int change)
    {
        var conflict = Conflicts.Find(c => c.Kingdom == kingdom);
        if (conflict == null) return;

        conflict.PopularSupport += change;
        if (conflict.PopularSupport >= 70 && !conflict.RegimeChanged)
        {
            conflict.RegimeChanged = true;
            Console.WriteLine($"\uD83C\uDFDB\uFE0F O reino {kingdom} mudou de regime devido \u00e0 press\u00e3o popular!");
        }
    }

    public static void PrintConflicts()
    {
        foreach (var c in Conflicts)
        {
            Console.WriteLine($"\n\uD83D\uDD04 {c.Kingdom} | Doutrina: {c.OfficialDoctrine} | Vers\u00e3o popular: {c.PopularVersion} | Apoio: {c.PopularSupport}% | Mudou? {c.RegimeChanged}");
        }
    }
}
