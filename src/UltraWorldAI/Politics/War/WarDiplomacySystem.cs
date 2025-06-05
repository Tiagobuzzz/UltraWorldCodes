using System;
using System.Collections.Generic;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public class Treaty
{
    public string BetweenA { get; set; } = string.Empty;
    public string BetweenB { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Aliança, Paz Temporária, Armistício, Enganação
    public DateTime SignedAt { get; set; }
    public bool Broken { get; set; }
}

public static class WarDiplomacySystem
{
    public static List<Treaty> Treaties { get; } = new();

    public static void ProposeTreaty(string a, string b, string type)
    {
        var rand = new Random();
        bool willBreak = type == "Enganação" && rand.NextDouble() < 0.8;

        Treaties.Add(new Treaty
        {
            BetweenA = a,
            BetweenB = b,
            Type = type,
            SignedAt = DateTime.Now,
            Broken = willBreak
        });

        SettlementHistoryTracker.Register(a, "Tratado", $"{type} com {b} {(willBreak ? "(planeja trair)" : string.Empty)}");
    }

    public static void EvaluateTreaties()
    {
        foreach (var t in Treaties)
        {
            if (t.Type == "Enganação" && !t.Broken && new Random().NextDouble() < 0.5)
            {
                t.Broken = true;
                SettlementHistoryTracker.Register(t.BetweenA, "Traição Diplomática", $"Quebrou tratado com {t.BetweenB}");
            }
        }
    }
}
