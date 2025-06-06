using System.Collections.Generic;

namespace UltraWorldAI.World;

public static class ResourceConsumptionTracker
{
    private static readonly Dictionary<string, double> _resources = new();

    public static void Register(string settlement, double amount)
    {
        _resources[settlement] = amount;
    }

    public static void Consume(string settlement, double amount)
    {
        if (!_resources.ContainsKey(settlement)) return;
        _resources[settlement] = System.Math.Max(0, _resources[settlement] - amount);
        double impact = amount * 0.05;
        MapFaithEconomyIntegration.UpdateNodeWealth(settlement, -impact);
    }

    public static double GetRemaining(string settlement) => _resources.GetValueOrDefault(settlement);
}
