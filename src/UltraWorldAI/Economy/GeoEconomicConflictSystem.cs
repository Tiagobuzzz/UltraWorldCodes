using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class TradeSanction
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public static class GeoEconomicConflictSystem
{
    public static List<TradeSanction> Sanctions { get; } = new();

    public static void DeclareSanction(string from, string to, string reason)
    {
        Sanctions.Add(new TradeSanction
        {
            From = from,
            To = to,
            Duration = 5,
            Reason = reason
        });

        SettlementHistoryTracker.Register(to, "Sanção Econômica", $"{from} sancionou por: {reason}");
    }

    public static void AdvanceSanctions()
    {
        foreach (var s in Sanctions)
            s.Duration--;
        Sanctions.RemoveAll(s => s.Duration <= 0);
    }

    public static void AttemptCorruption(string target, string actor)
    {
        var chance = Random.Shared.NextDouble();
        if (chance < 0.4)
            SettlementHistoryTracker.Register(target, "Corrupção", $"{actor} subornou líderes.");
        else
            SettlementHistoryTracker.Register(target, "Corrupção Falhou", $"{actor} tentou subornar sem sucesso.");
    }
}
