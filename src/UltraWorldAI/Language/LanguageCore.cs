using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class Language
{
    public string Name { get; set; } = string.Empty;
    public List<string> Phonemes { get; set; } = new();
    public List<string> RootWords { get; set; } = new();
    public string GrammarType { get; set; } = string.Empty;
    public string WritingSystem { get; set; } = string.Empty;
}

public static class LanguageCore
{
    public static List<Language> Languages { get; } = new();

    public static Language CreateLanguage(string name, List<string> phonemes, string grammar, string writing)
    {
        var lang = new Language
        {
            Name = name,
            Phonemes = phonemes,
            RootWords = new(),
            GrammarType = grammar,
            WritingSystem = writing
        };

        Languages.Add(lang);
        Console.WriteLine($"🌐 Linguagem criada: {name} ({grammar}, {writing})");
        return lang;
    }

    public static void AddRootWord(Language lang, string word)
    {
        lang.RootWords.Add(word);
    }

    public static void PrintLanguage(Language lang)
    {
        Console.WriteLine($"\n🗣️ Língua: {lang.Name} | Sistema: {lang.WritingSystem} | Ordem: {lang.GrammarType}");
        Console.WriteLine($"🔤 Fonemas: {string.Join(", ", lang.Phonemes)}");
        Console.WriteLine($"📚 Vocabulário raiz: {string.Join(", ", lang.RootWords)}");
    }
}
