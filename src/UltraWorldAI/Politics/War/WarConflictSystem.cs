using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public class War
{
    public string Attacker { get; set; } = string.Empty;
    public string Defender { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public bool IsOngoing { get; set; } = true;
}

public static class WarConflictSystem
{
    public static List<War> ActiveWars { get; } = new();

    public static void CheckForConflicts(List<Settlement> settlements)
    {
        var rand = new Random();

        for (int i = 0; i < settlements.Count; i++)
        {
            for (int j = i + 1; j < settlements.Count; j++)
            {
                var a = settlements[i];
                var b = settlements[j];

                if (a.Region == b.Region && a.Race != b.Race)
                {
                    if (rand.NextDouble() < 0.15)
                    {
                        string reason = GetReason(a, b);
                        ActiveWars.Add(new War
                        {
                            Attacker = a.Name,
                            Defender = b.Name,
                            Reason = reason,
                            StartDate = DateTime.Now
                        });

                        SettlementHistoryTracker.Register(a.Name, "Declaração de Guerra", $"Atacou {b.Name}: {reason}");
                    }
                }
            }
        }
    }

    private static string GetReason(Settlement a, Settlement b)
    {
        if (a.CultureSummary != b.CultureSummary) return "Conflito Cultural";
        if (Math.Abs(a.Population - b.Population) > 500) return "Ambição Expansionista";
        return "Disputa Territorial";
    }
}
