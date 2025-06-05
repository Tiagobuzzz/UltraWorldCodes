using System;
using System.Collections.Generic;
using UltraWorldAI.World;

namespace UltraWorldAI.Economy;

public class EconomicProfile
{
    public string Name { get; set; } = string.Empty;
    public double RiskTolerance { get; set; }
    public bool IsFraudulent { get; set; }
    public double Capital { get; set; }
}

public static class EconomicCrisisReactionAI
{
    public static List<EconomicProfile> Profiles { get; } = new();

    public static void RegisterIA(string name, double capital)
    {
        Profiles.Add(new EconomicProfile
        {
            Name = name,
            Capital = capital,
            RiskTolerance = Random.Shared.NextDouble(),
            IsFraudulent = false
        });
    }

    public static void EvaluateCrisis(string settlement, double inflation)
    {
        foreach (var ia in Profiles)
        {
            if (inflation > 1.5 && ia.RiskTolerance > 0.7)
            {
                ia.Capital *= 1.2;
                SettlementHistoryTracker.Register(settlement, "Especulação", $"{ia.Name} lucrou durante a crise.");
                if (Random.Shared.NextDouble() < 0.3)
                {
                    ia.IsFraudulent = true;
                    SettlementHistoryTracker.Register(settlement, "Fraude", $"{ia.Name} iniciou um esquema fraudulento.");
                }
            }
            else if (inflation > 2.0)
            {
                ia.Capital *= 0.7;
                SettlementHistoryTracker.Register(settlement, "Perda Econômica", $"{ia.Name} perdeu riqueza na crise.");
            }
        }
    }
}
