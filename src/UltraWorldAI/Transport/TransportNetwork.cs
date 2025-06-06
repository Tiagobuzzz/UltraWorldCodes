using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Transport;

public class Route
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public int Distance { get; set; }
}

/// <summary>
/// Simple collection of transportation routes.
/// </summary>
public static class TransportNetwork
{
    public static List<Route> Routes { get; } = new();

    public static void AddRoute(string from, string to, int distance)
    {
        Routes.Add(new Route { From = from, To = to, Distance = distance });
    }

    public static Route? GetRoute(string from, string to)
    {
        return Routes.FirstOrDefault(r => r.From == from && r.To == to);
    }
}
