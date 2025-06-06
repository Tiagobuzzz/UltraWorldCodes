using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Politics;

public record PoliticalEra(string Kingdom, int StartYear, int EndYear, GovernmentType GovernmentType);

public static class PoliticalEvolutionTracker
{
    private static readonly List<PoliticalEra> _history = new();

    public static void AddEra(string kingdom, int startYear, int endYear, GovernmentType type)
    {
        _history.Add(new PoliticalEra(kingdom, startYear, endYear, type));
    }

    public static IEnumerable<PoliticalEra> HistoryOf(string kingdom)
    {
        return _history.Where(e => e.Kingdom == kingdom).OrderBy(e => e.StartYear);
    }
}
