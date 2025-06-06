using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticRegion
{
    public string Empire { get; set; } = string.Empty;
    public List<string> SpokenLanguages { get; set; } = new();
    public string OfficialLanguage { get; set; } = string.Empty;
    public Dictionary<string, double> Tensions { get; set; } = new();
}

public static class LinguisticConflictSystem
{
    public static List<LinguisticRegion> Regions { get; } = new();

    public static void AddRegion(string empire, List<string> languages, string official)
    {
        var region = new LinguisticRegion
        {
            Empire = empire,
            SpokenLanguages = languages,
            OfficialLanguage = official
        };

        foreach (var lang in languages)
            region.Tensions[lang] = lang == official ? 0 : 0.5;

        Regions.Add(region);
    }

    public static void EnforceLanguage(string empire, string language)
    {
        var region = Regions.Find(r => r.Empire == empire);
        if (region == null) return;

        region.OfficialLanguage = language;

        foreach (var lang in region.SpokenLanguages)
        {
            if (lang != language)
                region.Tensions[lang] += 0.3;
        }

        Console.WriteLine($"\uD83D\uDCE3 {empire} imp\u00F4s {language} como l\u00EDngua oficial. Tens\u00F5es aumentam.");
    }

    public static void PrintTensions(string empire)
    {
        var region = Regions.Find(r => r.Empire == empire);
        if (region == null) return;
        Console.WriteLine($"\n\uD83D\uDDFA\uFE0F Tens\u00F5es lingu\u00EDsticas em {empire}:");
        foreach (var kv in region.Tensions)
            Console.WriteLine($"\uD83D\uDCAC {kv.Key} \u2192 tens\u00E3o: {kv.Value}");
    }
}
