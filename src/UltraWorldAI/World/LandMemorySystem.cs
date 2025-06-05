using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class LandMemory
{
    public string RegionName { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;
    public string Impact { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public static class LandMemorySystem
{
    public static List<LandMemory> Memories { get; } = new();

    public static void RecordEvent(string region, string evt, string impact)
    {
        Memories.Add(new LandMemory
        {
            RegionName = region,
            Event = evt,
            Impact = impact,
            Date = DateTime.Now
        });
    }

    public static string DescribeAll()
    {
        if (Memories.Count == 0) return "A terra ainda não guarda memórias.";
        return string.Join("\n\n", Memories.ConvertAll(m =>
            $"\uD83D\uDDFF Em {m.RegionName}: {m.Event} ({m.Date.ToShortDateString()})\nImpacto: {m.Impact}"));
    }
}
