using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticAssassination
{
    public string Speaker { get; set; } = string.Empty;
    public string Word { get; set; } = string.Empty;
    public string Context { get; set; } = string.Empty; // "Religioso", "Político", "Cultural"
    public string Outcome { get; set; } = string.Empty;
    public int Year { get; set; }
}

public static class LinguisticAssassinationSystem
{
    public static List<LinguisticAssassination> Records { get; } = new();

    public static void Execute(string speaker, string word, string context, string outcome, int year)
    {
        Records.Add(new LinguisticAssassination
        {
            Speaker = speaker,
            Word = word,
            Context = context,
            Outcome = outcome,
            Year = year
        });

        Console.WriteLine($"\uD83D\uDD2A {speaker} foi executado por dizer '{word}' ({context}) – Resultado: {outcome} ({year})");
    }

    public static void PrintExecutions()
    {
        foreach (var r in Records)
        {
            Console.WriteLine($"\n\u2696\uFE0F {r.Year} | {r.Speaker} | Palavra: {r.Word} | Contexto: {r.Context} → {r.Outcome}");
        }
    }
}
