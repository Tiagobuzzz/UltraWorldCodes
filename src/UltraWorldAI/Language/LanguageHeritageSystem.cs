using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LanguageHeritage
{
    public string Culture { get; set; } = string.Empty;
    public List<string> Languages { get; set; } = new();
}

public static class LanguageHeritageSystem
{
    public static List<LanguageHeritage> Heritages { get; } = new();

    public static void AddLanguage(string culture, string language)
    {
        var heritage = Heritages.Find(h => h.Culture == culture);
        if (heritage == null)
        {
            heritage = new LanguageHeritage { Culture = culture };
            Heritages.Add(heritage);
        }
        if (!heritage.Languages.Contains(language))
            heritage.Languages.Add(language);
    }

    public static void RemoveLanguage(string culture, string language)
    {
        var heritage = Heritages.Find(h => h.Culture == culture);
        if (heritage == null) return;
        heritage.Languages.Remove(language);
        if (heritage.Languages.Count == 0)
            Console.WriteLine($"\uD83D\uDE2D {culture} lamenta a perda da l\u00edngua '{language}'.");
    }

    public static void PrintLanguages(string culture)
    {
        var heritage = Heritages.Find(h => h.Culture == culture);
        if (heritage != null)
            Console.WriteLine($"\n\uD83C\uDF0D {culture} preserva: {string.Join(", ", heritage.Languages)}");
    }
}
