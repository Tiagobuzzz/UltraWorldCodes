using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.World.Ecology;

public class ClimateEvent
{
    public string Type { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public static class ClimateEventSystem
{
    private static readonly Random _rand = new();
    private static readonly string[] _types = new[] { "Chuva", "Seca", "Tempestade", "Nevasca", "Furacao", "Granizo" };
    public static List<ClimateEvent> Events { get; } = new();

    public static ClimateEvent Generate(string region)
    {
        var evt = new ClimateEvent
        {
            Type = _types[_rand.Next(_types.Length)],
            Region = region,
            Date = DateTime.Now
        };
        Events.Add(evt);
        return evt;
    }

    public static void AdvanceDay(IEnumerable<string> regions)
    {
        foreach (var region in regions)
        {
            if (_rand.NextDouble() < 0.1)
                Generate(region);
        }
    }

    public static string Summary()
    {
        return string.Join("\n", Events.Select(e => $"{e.Date.ToShortDateString()} {e.Region}: {e.Type}"));
    }
}
