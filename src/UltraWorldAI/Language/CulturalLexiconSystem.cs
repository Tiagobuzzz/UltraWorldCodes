using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class CulturalLexicon
{
    public string CultureName { get; set; } = string.Empty;
    public string LanguageName { get; set; } = string.Empty;
    public Dictionary<string, string> MeaningToWord { get; set; } = new();
}

public static class CulturalLexiconSystem
{
    public static List<CulturalLexicon> Lexicons { get; } = new();

    public static void CreateLexicon(string culture, string language)
    {
        Lexicons.Add(new CulturalLexicon
        {
            CultureName = culture,
            LanguageName = language,
            MeaningToWord = new Dictionary<string, string>()
        });
    }

    public static void AddWord(string culture, string meaning, string word)
    {
        var lex = Lexicons.Find(l => l.CultureName == culture);
        if (lex != null)
            lex.MeaningToWord[meaning] = word;
    }

    public static void PrintLexicon(string culture)
    {
        var lex = Lexicons.Find(l => l.CultureName == culture);
        if (lex != null)
        {
            Console.WriteLine($"\n📚 Léxico cultural de {culture}:");
            foreach (var entry in lex.MeaningToWord)
                Console.WriteLine($"🔑 {entry.Key} → {entry.Value}");
        }
    }
}
