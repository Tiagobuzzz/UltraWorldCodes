using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World;

namespace UltraWorldAI.Economy;

public static class TradeRouteGenerator
{
    public static List<(string From, string To)> Routes { get; } = new();

    public static void GenerateRoutes()
    {
        Routes.Clear();
        var settlements = RaceSettlementDistributor.Settlements;
        var rand = new Random();
        foreach (var from in settlements)
        {
            var toOptions = settlements.Where(s => s.Region != from.Region).ToList();
            if (toOptions.Count == 0) continue;
            var to = toOptions[rand.Next(toOptions.Count)];
            Routes.Add((from.Name, to.Name));
        }
    }
}
