using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public class DivineWord
{
    public string Language { get; set; } = string.Empty;
    public string GodName { get; set; } = string.Empty;
    public List<string> SacredWords { get; set; } = new();
    public string ProphecyTrigger { get; set; } = string.Empty;
}

public static class DivineLinguisticConnectionSystem
{
    public static List<DivineWord> Registry { get; } = new();

    public static void RegisterDivineWord(string language, string god, List<string> words, string prophecy)
    {
        Registry.Add(new DivineWord
        {
            Language = language,
            GodName = god,
            SacredWords = words,
            ProphecyTrigger = prophecy
        });

        Console.WriteLine($"\ud83c\udf90 Deus {god} vinculado \u00e0 l\u00edngua {language}. Palavras sagradas: {string.Join(", ", words)}");
    }

    public static void Speak(string speaker, string language, string word)
    {
        var match = Registry.Find(d => d.Language == language && d.SacredWords.Contains(word));
        if (match != null)
            Console.WriteLine($"\ud83d\udd2e {speaker} pronunciou '{word}' em {language} \u2014 a aten\u00e7\u00e3o de {match.GodName} foi despertada: {match.ProphecyTrigger}");
        else
            Console.WriteLine($"{speaker} disse '{word}' sem impacto divino.");
    }
}
