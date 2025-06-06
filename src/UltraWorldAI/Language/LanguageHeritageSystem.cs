using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LanguageHeritage
{
    public string Culture { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    // 0-1 scale of emotional attachment
    public double EmotionalAttachment { get; set; }
    public bool IsSuppressed { get; set; }
    public bool IsExtinct { get; set; }
}

public static class LanguageHeritageSystem
{
    public static List<LanguageHeritage> Heritages { get; } = new();

    public static void RegisterHeritage(string culture, string language, double attachment)
    {
        Heritages.Add(new LanguageHeritage
        {
            Culture = culture,
            Language = language,
            EmotionalAttachment = attachment,
            IsSuppressed = false,
            IsExtinct = false
        });
    }

    public static void SuppressLanguage(string culture)
    {
        var heritage = Heritages.Find(h => h.Culture == culture);
        if (heritage == null) return;
        heritage.IsSuppressed = true;
        Console.WriteLine($"\u26A0\uFE0F A l\u00EDngua {heritage.Language} foi suprimida em {culture}.");
    }

    public static void ExtinguishLanguage(string culture)
    {
        var heritage = Heritages.Find(h => h.Culture == culture);
        if (heritage == null) return;
        heritage.IsExtinct = true;
        Console.WriteLine($"\uD83D\uDC80 A l\u00EDngua {heritage.Language} foi extinta. {culture} sofre trauma cultural.");
    }

    public static void ReactToLoss(string culture)
    {
        var heritage = Heritages.Find(h => h.Culture == culture);
        if (heritage == null) return;

        double rage = heritage.EmotionalAttachment * (heritage.IsSuppressed ? 0.5 : 0) + (heritage.IsExtinct ? 1 : 0);
        if (rage > 0.7)
            Console.WriteLine($"\uD83D\uDD25 {culture} inicia revolta lingu\u00EDstica pela perda da l\u00EDngua {heritage.Language}!");
    }
}
