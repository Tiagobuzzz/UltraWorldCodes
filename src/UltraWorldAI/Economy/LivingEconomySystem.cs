using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World;

namespace UltraWorldAI.Economy;

public class Good
{
    public string Name { get; set; } = string.Empty;
    public double BaseValue { get; set; }
    public double Quantity { get; set; }
}

public class Market
{
    public string Settlement { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public Dictionary<string, Good> Goods { get; } = new();
    public double InflationFactor { get; set; } = 1.0;
}

public static class LivingEconomySystem
{
    public static List<Market> AllMarkets { get; } = new();

    public static void InitMarket(string settlement, string culture)
    {
        string[] goods = new[] { "Comida", "Ferro", "Tecidos", "Cristais", "Arte", "Runas" };
        var market = new Market
        {
            Settlement = settlement,
            Currency = GenerateCurrencyName(culture)
        };

        foreach (var g in goods)
        {
            market.Goods[g] = new Good
            {
                Name = g,
                BaseValue = RandomSingleton.Shared.Next(10, 100),
                Quantity = RandomSingleton.Shared.Next(50, 500)
            };
        }

        AllMarkets.Add(market);
        SettlementHistoryTracker.Register(settlement, "Economia Ativada", $"Mercado com moeda {market.Currency} estabelecido.");
    }

    public static double GetCurrentPrice(Market market, string goodName)
    {
        if (!market.Goods.ContainsKey(goodName)) return -1;
        var good = market.Goods[goodName];
        double scarcityFactor = 1 + ((100 - good.Quantity) / 100.0);
        return good.BaseValue * scarcityFactor * market.InflationFactor;
    }

    public static void SimulateYear()
    {
        foreach (var market in AllMarkets)
        {
            foreach (var good in market.Goods.Values)
            {
                good.Quantity += RandomSingleton.Shared.Next(-50, 60);
                if (good.Quantity < 5) good.Quantity = 5;
            }

            if (RandomSingleton.Shared.NextDouble() < 0.1)
            {
                market.InflationFactor += 0.1;
                SettlementHistoryTracker.Register(market.Settlement, "Inflação", "Preços subiram por instabilidade interna.");
            }

            EconomicCrisisReactionAI.EvaluateCrisis(market.Settlement, market.InflationFactor);
        }
    }

    private static string GenerateCurrencyName(string culture)
    {
        string[] roots = new[] { "Zel", "Orin", "Tal", "Myth", "Ren", "Vak" };
        string[] suffix = new[] { "coin", "dar", "ron", "tal", "ael" };
        return roots[RandomSingleton.Shared.Next(roots.Length)] + suffix[RandomSingleton.Shared.Next(suffix.Length)];
    }
}
