using System;
using System.Collections.Generic;
using UltraWorldAI.Religion;

namespace UltraWorldAI.Language;

public class LanguagePropagation
{
    public string Language { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Initiator { get; set; } = string.Empty;
    public string Mode { get; set; } = string.Empty; // Culto, Tradicao, Resistencia
}

public static class MysticLanguagePropagationSystem
{
    public static List<LanguagePropagation> Propagations { get; } = new();

    public static void Propagate(string language, string region, string initiator, string mode)
    {
        Propagations.Add(new LanguagePropagation
        {
            Language = language,
            Region = region,
            Initiator = initiator,
            Mode = mode
        });

        Console.WriteLine($"\ud83c\udf10 L\u00edngua {language} propagada como {mode} em {region} por {initiator}");

        switch (mode)
        {
            case "Culto":
                HiddenCultSystem.SeedCult(language, region);
                break;
            case "Tradicao":
                LanguageHeritageSystem.RegisterHeritage(region, language, 0.5);
                break;
            case "Resistencia":
                LanguageHeritageSystem.RegisterHeritage(region, language, 0.9);
                break;
        }
    }
}
