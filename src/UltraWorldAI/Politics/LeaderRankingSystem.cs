using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Politics;

/// <summary>
/// Maintains a ranking of historical leaders based on influence points.
/// </summary>
public static class LeaderRankingSystem
{
    private static readonly Dictionary<string, double> _leaders = new();

    public static void Register(string leaderName, double influence)
    {
        if (_leaders.ContainsKey(leaderName))
            _leaders[leaderName] += influence;
        else
            _leaders[leaderName] = influence;
    }

    public static IList<string> GetTop(int count)
    {
        return _leaders
            .OrderByDescending(kvp => kvp.Value)
            .Take(count)
            .Select(kvp => kvp.Key)
            .ToList();
    }
}
