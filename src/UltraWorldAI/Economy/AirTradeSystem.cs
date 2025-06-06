using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class AirHub
{
    public string Name { get; set; } = string.Empty;
}

public class AirRoute
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public int Distance { get; set; }
    public List<string> Goods { get; } = new();
}

public static class AirTradeSystem
{
    public static List<AirHub> Hubs { get; } = new();
    public static List<AirRoute> Routes { get; } = new();
    private static readonly Random _rng = new();

    public static void RegisterHub(string name)
    {
        if (!Hubs.Any(h => h.Name == name))
            Hubs.Add(new AirHub { Name = name });
    }

    public static AirRoute AddRoute(string from, string to, int distance)
    {
        var route = new AirRoute { From = from, To = to, Distance = distance };
        Routes.Add(route);
        return route;
    }

    public static float SimulateFlight(AirRoute route, string good, float baseValue)
    {
        route.Goods.Add(good);
        var distanceFactor = 1f + route.Distance / 200f;
        var random = 0.5f + (float)_rng.NextDouble();
        return baseValue * distanceFactor * random;
    }
}

