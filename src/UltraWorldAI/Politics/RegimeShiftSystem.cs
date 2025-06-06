using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public record RegimeShiftEvent(int Year, string Region, string From, string To);

/// <summary>
/// Records abrupt regime change events.
/// </summary>
public static class RegimeShiftSystem
{
    public static List<RegimeShiftEvent> History { get; } = new();

    public static void AddEvent(int year, string region, string from, string to)
    {
        History.Add(new RegimeShiftEvent(year, region, from, to));
    }
}
