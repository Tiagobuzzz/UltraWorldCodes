using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class TouristSpot
{
    public string Name { get; set; } = string.Empty;
    public int Visitors { get; set; }
    public double Revenue { get; set; }
}

/// <summary>
/// Tracks tourism and calculates economic impact.
/// </summary>
public static class TourismSystem
{
    public static List<TouristSpot> Spots { get; } = new();

    public static void RegisterSpot(string name)
    {
        Spots.Add(new TouristSpot { Name = name });
    }

    public static void Visit(string name, int count, double ticketPrice)
    {
        var spot = Spots.Find(s => s.Name == name);
        if (spot == null) return;
        spot.Visitors += count;
        spot.Revenue += count * ticketPrice;
    }
}
