using System;
using System.Linq;

namespace UltraWorldAI.World;

public static class SettlementFusionSystem
{
    private static readonly Random Rand = new();

    public static void AttemptFusion()
    {
        var settlements = RaceSettlementDistributor.Settlements;

        for (int i = 0; i < settlements.Count - 1; i++)
        {
            var a = settlements[i];
            var b = settlements[i + 1];

            if (a.Region == b.Region && a.Race == b.Race && Rand.NextDouble() < 0.25)
            {
                string fusionName = $"{a.Name.Split(' ')[0]}-{b.Name.Split(' ')[0]} União";
                int newPop = a.Population + b.Population;

                settlements.RemoveAt(i + 1);
                settlements.RemoveAt(i);

                settlements.Add(new Settlement
                {
                    Name = fusionName,
                    Region = a.Region,
                    Race = a.Race,
                    CultureSummary = "Confederação Cultural",
                    Population = newPop
                });

                SettlementHistoryTracker.Register(fusionName, "Fusão", $"Fusão entre {a.Name} e {b.Name}");
                i--;
            }
        }
    }

    public static void PromoteCivilization(Settlement settlement)
    {
        if (settlement.Population > 5000 && settlement.CultureSummary.Contains("Confederação"))
        {
            settlement.CultureSummary = "Civilização Global Emergente";
            SettlementHistoryTracker.Register(settlement.Name, "Ascensão Civilizacional", "Nova superpotência cultural global");
        }
    }
}
