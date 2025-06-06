using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class ExtinctLanguage
{
    public string Name { get; set; } = string.Empty;
    public int YearLost { get; set; }
    public bool IsBeingRevived { get; set; }
    public double RevivalAccuracy { get; set; } // 0-1
}

public static class LanguageExtinctionSystem
{
    public static List<ExtinctLanguage> Extinct { get; } = new();

    public static void DeclareExtinction(string name, int year)
    {
        Extinct.Add(new ExtinctLanguage
        {
            Name = name,
            YearLost = year,
            IsBeingRevived = false,
            RevivalAccuracy = 0
        });

        Console.WriteLine($"\uD83D\uDC80 A l\u00EDngua {name} foi extinta no ano {year}.");
    }

    public static void AttemptRevival(string name)
    {
        var lang = Extinct.Find(l => l.Name == name);
        if (lang == null || lang.IsBeingRevived) return;

        lang.IsBeingRevived = true;
        lang.RevivalAccuracy = new Random().NextDouble() * 0.6;

        Console.WriteLine($"\uD83C\uDF31 Tentativa de reviver {name} iniciada. Precis\u00E3o hist\u00F3rica: {lang.RevivalAccuracy * 100:F1}%");
    }

    public static void PrintExtinctLanguages()
    {
        foreach (var l in Extinct)
        {
            Console.WriteLine($"\n\uD83D\uDD6F️ {l.Name} | Extinta em: {l.YearLost} | Revivendo? {l.IsBeingRevived} | Precis\u00E3o: {l.RevivalAccuracy:F2}");
        }
    }
}
