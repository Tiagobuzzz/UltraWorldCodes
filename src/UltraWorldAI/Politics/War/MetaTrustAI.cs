using System;
using System.Collections.Generic;
using UltraWorldAI.Civilization;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public class SecretPlan
{
    public string Actor { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public string PlanType { get; set; } = string.Empty; // Traição, Infiltração
    public int TurnsToExecute { get; set; }
}

public static class MetaTrustAI
{
    public static List<SecretPlan> Plans { get; } = new();

    public static void EvaluateMetaTrust(SapientBeing ia, Settlement target)
    {
        var rand = Random.Shared;
        var rel = SettlementHistoryTracker.GetRelation(ia.CurrentRegion, target.Name);

        bool isTrusted = rel.Contains("aliança", StringComparison.OrdinalIgnoreCase) && rand.NextDouble() < 0.7;
        bool hasPastConflict = rel.Contains("traição", StringComparison.OrdinalIgnoreCase) ||
                               rel.Contains("guerra", StringComparison.OrdinalIgnoreCase);

        if (isTrusted && !hasPastConflict && rand.NextDouble() < 0.3)
        {
            string plan = rand.NextDouble() < 0.5 ? "Traição" : "Infiltração";
            Plans.Add(new SecretPlan
            {
                Actor = ia.Name,
                Target = target.Name,
                PlanType = plan,
                TurnsToExecute = rand.Next(3, 8)
            });

            Console.WriteLine($"\uD83E\uDD16 {ia.Name} finge amizade com {target.Name}, mas planeja: {plan}");
        }
    }

    public static void AdvancePlans()
    {
        foreach (var plan in Plans.ToArray())
        {
            plan.TurnsToExecute--;
            if (plan.TurnsToExecute <= 0)
            {
                Console.WriteLine($"\uD83D\uDD25 {plan.Actor} executa plano oculto contra {plan.Target}: {plan.PlanType}");
                SettlementHistoryTracker.Register(plan.Target, "Traição Estratégica",
                    $"{plan.Actor} executou plano de {plan.PlanType}");
                Plans.Remove(plan);
            }
        }
    }
}
