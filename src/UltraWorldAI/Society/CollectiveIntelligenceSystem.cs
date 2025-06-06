using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Society;

/// <summary>
/// Demonstrates a simple swarm intelligence mechanism for collective decisions.
/// </summary>
public static class CollectiveIntelligenceSystem
{
    public static string Decide(IEnumerable<string> options, IEnumerable<string> votes)
    {
        var majority = votes
            .GroupBy(v => v)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
        return majority ?? options.First();
    }
}
