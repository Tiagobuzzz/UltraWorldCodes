using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class Port
{
    public string Name { get; set; } = string.Empty;
}

public class NavalRoute
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public int Distance { get; set; }
    public List<string> Goods { get; } = new();
}

public static class MaritimeTradeSystem
{
    public static List<Port> Ports { get; } = new();
    public static List<NavalRoute> Routes { get; } = new();
    private static readonly Random _rng = new();

    public static void RegisterPort(string name)
    {
        if (!Ports.Any(p => p.Name == name))
            Ports.Add(new Port { Name = name });
    }

    public static NavalRoute AddRoute(string from, string to, int distance)
    {
        var route = new NavalRoute { From = from, To = to, Distance = distance };
        Routes.Add(route);
        return route;
    }

    public static float SimulateVoyage(NavalRoute route, string good, float baseValue)
    {
        route.Goods.Add(good);
        var distanceFactor = 1f + route.Distance / 100f;
        var random = 0.5f + (float)_rng.NextDouble();
        return baseValue * distanceFactor * random;
    }
}
