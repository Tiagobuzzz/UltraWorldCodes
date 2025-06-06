using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public static class CommodityMarketSystem
{
    private static readonly Random Rand = new();
    public static readonly Dictionary<string, double> Prices = new();

    public static void RegisterCommodity(string name, double initialPrice)
    {
        Prices[name] = initialPrice;
    }

    public static void TickMarket()
    {
        foreach (var key in Prices.Keys.ToList())
        {
            var change = (Rand.NextDouble() - 0.5) * 0.1 * Prices[key];
            Prices[key] = Math.Max(0.01, Prices[key] + change);
        }
    }

    public static double GetPrice(string name)
    {
        return Prices.TryGetValue(name, out var p) ? p : 0.0;
    }
}
