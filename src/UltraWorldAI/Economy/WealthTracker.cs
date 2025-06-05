using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public static class WealthTracker
{
    public static Dictionary<string, int> Wealth { get; } = new();

    public static void AdjustWealth(string settlement, int amount)
    {
        if (!Wealth.ContainsKey(settlement))
            Wealth[settlement] = 0;
        Wealth[settlement] += amount;
    }
}
