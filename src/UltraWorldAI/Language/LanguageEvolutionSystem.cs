using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

/// <summary>
/// Evolves languages over time by applying random dialect shifts.
/// </summary>
public static class LanguageEvolutionSystem
{
    private static readonly Random _rand = new();

    public static void Evolve(LanguageSeed language)
    {
        if (_rand.NextDouble() < 0.5)
            DialectShiftEngine.EvolveDialect(language);
    }

    public static string MutateWord(string word)
    {
        if (word.Length < 2) return word;

        int index = _rand.Next(word.Length);
        char c = (char)('a' + _rand.Next(0, 26));
        return word.Substring(0, index) + c + word[(index + 1)..];
    }

    public static void MutateLexicon(string culture)
    {
        var lex = CulturalLexiconSystem.Lexicons.Find(l => l.CultureName == culture);
        if (lex == null) return;

        var mutated = new Dictionary<string, string>();
        foreach (var pair in lex.MeaningToWord)
            mutated[pair.Key] = MutateWord(pair.Value);

        lex.MeaningToWord = mutated;
        Console.WriteLine($"🧬 Léxico de {culture} sofreu mutação linguística.");
    }
}

