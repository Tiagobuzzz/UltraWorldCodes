using System;
using System.Collections.Generic;
using UltraWorldAI.Religion;
using UltraWorldAI;

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
    public static Dictionary<string, Doctrine> LanguageDoctrines { get; } = new();

    private static Doctrine GetOrCreateDoctrine(string language)
    {
        if (LanguageDoctrines.TryGetValue(language, out var doctrine))
            return doctrine;

        var god = GodFactory.CreateGod($"Espirito de {language}", DivineDomain.Silencio, DivineTemperament.Dual);
        doctrine = DoctrineEngine.CreateDoctrine(god);
        DoctrineEngine.AddHeresy(doctrine, $"Culto linguistico de {language}");
        LanguageDoctrines[language] = doctrine;
        return doctrine;
    }

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
                GetOrCreateDoctrine(language);
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
