using System;
using System.Linq;

namespace UltraWorldAI.World;

/// <summary>
/// Simple AI that balances resource consumption across settlements
/// using the existing ResourceConsumptionTracker and economic nodes.
/// </summary>
public static class ResourceManagementAI
{
    public static void BalanceResources()
    {
        foreach (var node in MapFaithEconomyIntegration.Nodes)
        {
            var remaining = ResourceConsumptionTracker.GetRemaining(node.Settlement);
            if (remaining <= 0) continue;
            double adjustment = remaining switch
            {
                < 20 => 5,
                > 100 => -5,
                _ => 0
            };
            if (adjustment != 0)
            {
                ResourceConsumptionTracker.Consume(node.Settlement, Math.Abs(adjustment));
                MapFaithEconomyIntegration.UpdateNodeWealth(node.Settlement, adjustment);
            }
        }
    }
}
