using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World;

namespace UltraWorldAI.Religion;

public class HiddenCult
{
    public string Name { get; set; } = string.Empty;
    public string BeliefSystem { get; set; } = string.Empty;
    public string TargetSettlement { get; set; } = string.Empty;
    public int InfluenceLevel { get; set; }
    public bool Discovered { get; set; }
}

public static class HiddenCultSystem
{
    public static List<HiddenCult> ActiveCults { get; } = new();

    public static void SeedCult(string beliefSystem, string targetSettlement)
    {
        if (ActiveCults.Any(c => c.TargetSettlement == targetSettlement && !c.Discovered))
            return;

        var cult = new HiddenCult
        {
            Name = $"Culto de {beliefSystem}",
            BeliefSystem = beliefSystem,
            TargetSettlement = targetSettlement,
            InfluenceLevel = 10
        };

        ActiveCults.Add(cult);
        SettlementHistoryTracker.Register(targetSettlement, "Infiltração Espiritual",
            $"Um culto secreto de {beliefSystem} começou a se formar.");
    }

    public static void AdvanceCultInfluence()
    {
        foreach (var cult in ActiveCults)
        {
            if (cult.Discovered)
                continue;

            cult.InfluenceLevel += Random.Shared.Next(1, 6);

            if (cult.InfluenceLevel >= 70)
            {
                SettlementHistoryTracker.Register(cult.TargetSettlement, "Conversão Silenciosa",
                    $"Grande parte da vila agora acredita em {cult.BeliefSystem}.");
                CultureBeliefSystem.ForceChangeBelief(cult.TargetSettlement, cult.BeliefSystem);
                cult.Discovered = true;
            }
            else if (Random.Shared.NextDouble() < 0.05)
            {
                cult.Discovered = true;
                SettlementHistoryTracker.Register(cult.TargetSettlement, "Culto Descoberto",
                    $"Autoridades locais descobriram o culto secreto de {cult.BeliefSystem}.");
            }
        }
    }
}
