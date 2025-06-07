using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class MagicLaw
{
    public string Name = string.Empty;
    public string RequiredCondition = string.Empty; // "Lua cheia", "Sangue de irmão", "Silêncio absoluto"
    public string Cost = string.Empty; // "Memória", "Vida", "Cordura", "Força vital"
    public string Risk = string.Empty; // "Mutação", "Corrupção", "Loucuras temporais"
}

public static class MagicRulesAndRisksSystem
{
    public static List<MagicLaw> Laws { get; } = new();

    public static void AddLaw(string name, string condition, string cost, string risk)
    {
        Laws.Add(new MagicLaw
        {
            Name = name,
            RequiredCondition = condition,
            Cost = cost,
            Risk = risk
        });

        Console.WriteLine($"\u26A0\uFE0F Lei mágica: {name} | Condição: {condition} | Custo: {cost} | Risco: {risk}");
    }

    public static void PrintLaws()
    {
        foreach (var l in Laws)
            Console.WriteLine($"\n\uD83D\uDCDC {l.Name} | Condição: {l.RequiredCondition} | Custo: {l.Cost} | Risco: {l.Risk}");
    }
}
