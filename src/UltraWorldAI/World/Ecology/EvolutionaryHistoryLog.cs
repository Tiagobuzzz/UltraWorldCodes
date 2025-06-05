using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Ecology;

public class EvolutionLogEntry
{
    public string SpeciesName { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Change { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public static class EvolutionaryHistoryLog
{
    public static List<EvolutionLogEntry> History { get; } = new();

    public static void Record(string species, string region, string change, string cause)
    {
        History.Add(new EvolutionLogEntry
        {
            SpeciesName = species,
            Region = region,
            Change = change,
            Cause = cause,
            Date = DateTime.Now
        });
    }

    public static string Summary()
    {
        return string.Join("\n\n", History.ConvertAll(e => $"\uD83D\uDCDC {e.SpeciesName} em {e.Region}\nMudança: {e.Change} ({e.Cause}) em {e.Date.ToShortDateString()}"));
    }
}
