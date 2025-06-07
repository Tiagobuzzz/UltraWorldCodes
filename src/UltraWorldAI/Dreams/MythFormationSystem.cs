using System;
using System.Collections.Generic;
using UltraWorldAI.Religion;

namespace UltraWorldAI.Dreams;

public class LivingMyth
{
    public string Symbol = string.Empty;
    public string OriginDreamer = string.Empty;
    public string Manifestation = string.Empty;
    public string Effect = string.Empty;
}

public static class MythFormationSystem
{
    public static List<LivingMyth> Myths { get; } = new();

    public static void GenerateMyth(string symbol, string founder, string manifestation, string effect)
    {
        Myths.Add(new LivingMyth
        {
            Symbol = symbol,
            OriginDreamer = founder,
            Manifestation = manifestation,
            Effect = effect
        });

        Console.WriteLine($"\uD83D\uDD39 MITO NASCEU: '{symbol}' se tornou {manifestation} | Fundador: {founder} | Efeito: {effect}");
    }

    public static void CreateProphecyFromMyth(string symbol, string title, string prediction)
    {
        ProphecySystem.Create(title, symbol, "mito", symbol, prediction);
    }
}
