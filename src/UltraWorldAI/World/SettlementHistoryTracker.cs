using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class SettlementEvent
{
    public string SettlementName { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public static class SettlementHistoryTracker
{
    public static List<SettlementEvent> Events { get; } = new();

    public static void Register(string settlement, string type, string description)
    {
        Events.Add(new SettlementEvent
        {
            SettlementName = settlement,
            EventType = type,
            Description = description,
            Date = DateTime.Now
        });
    }

    public static string Summary()
    {
        return string.Join("\n\n", Events.ConvertAll(e => $"\uD83C\uDFE0 {e.SettlementName} - {e.EventType} em {e.Date.ToShortDateString()}\n{e.Description}"));
    }

    public static string GetRelation(string settlementA, string settlementB)
    {
        var related = Events.FindAll(e =>
            (e.SettlementName == settlementA && e.Description.Contains(settlementB, StringComparison.OrdinalIgnoreCase)) ||
            (e.SettlementName == settlementB && e.Description.Contains(settlementA, StringComparison.OrdinalIgnoreCase)));

        if (related.Count == 0) return string.Empty;
        return string.Join("|", related.ConvertAll(e => e.EventType.ToLowerInvariant()));
    }
}
