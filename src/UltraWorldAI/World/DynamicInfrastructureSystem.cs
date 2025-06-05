using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class Infrastructure
{
    public string Settlement { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Trigger { get; set; } = string.Empty;
}

public static class DynamicInfrastructureSystem
{
    public static List<Infrastructure> AllStructures { get; } = new();

    public static void UpdateInfrastructure()
    {
        foreach (var node in MapFaithEconomyIntegration.Nodes)
        {
            if (node.Wealth > 1500 && !node.HasMarket)
            {
                AllStructures.Add(new Infrastructure
                {
                    Settlement = node.Settlement,
                    Type = "Mercado Central",
                    Trigger = "Riqueza"
                });
                node.HasMarket = true;
                SettlementHistoryTracker.Register(node.Settlement, "Construção", "Mercado Central erguido.");
                Console.WriteLine($"\uD83D\uDD3D️ {node.Settlement} construiu um Mercado Central por excesso de riqueza.");
            }

            if (!node.HasTemple && !string.IsNullOrEmpty(node.DominantFaith))
            {
                AllStructures.Add(new Infrastructure
                {
                    Settlement = node.Settlement,
                    Type = $"Templo de {node.DominantFaith}",
                    Trigger = "Fé"
                });
                node.HasTemple = true;
                SettlementHistoryTracker.Register(node.Settlement, "Construção", $"Templo dedicado a {node.DominantFaith}");
                Console.WriteLine($"\uD83D\uDD3D️ {node.Settlement} ergueu o Templo de {node.DominantFaith} por influência espiritual.");
            }

            if (node.Wealth < 200 && node.HasMarket)
            {
                AllStructures.Add(new Infrastructure
                {
                    Settlement = node.Settlement,
                    Type = "Ruínas Comerciais",
                    Trigger = "Declínio"
                });
                node.HasMarket = false;
                SettlementHistoryTracker.Register(node.Settlement, "Declínio", "Mercado transformou-se em ruínas.");
                Console.WriteLine($"\uD83D\uDC80 {node.Settlement} perdeu seu mercado. Agora restam ruínas econômicas.");
            }
        }
    }
}
