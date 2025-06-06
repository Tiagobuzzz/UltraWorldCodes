using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Politics;

public class RevolutionEvent
{
    public int Year { get; set; }
    public string Cause { get; set; } = string.Empty;
}

public static class RevolutionPatternDetector
{
    public static List<RevolutionEvent> History { get; } = new();

    public static void AddEvent(int year, string cause)
    {
        History.Add(new RevolutionEvent { Year = year, Cause = cause });
    }

    public static List<string> GetCommonCauses()
    {
        return History
            .GroupBy(e => e.Cause)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();
    }

    public static int? GetAverageInterval()
    {
        if (History.Count < 2) return null;
        var ordered = History.OrderBy(e => e.Year).ToList();
        var diffs = new List<int>();
        for (int i = 1; i < ordered.Count; i++)
            diffs.Add(ordered[i].Year - ordered[i - 1].Year);
        return (int)diffs.Average();
    }
}
