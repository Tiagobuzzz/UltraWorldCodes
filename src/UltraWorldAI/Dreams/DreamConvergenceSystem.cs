using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Dreams;

public class DreamConvergence
{
    public string Symbol = string.Empty;
    public int Count;
    public List<string> Dreamers = new();
    public bool BecameMyth;
}

public static class DreamConvergenceSystem
{
    public static List<DreamConvergence> Convergences { get; } = new();

    public static void CheckConvergence()
    {
        var recentDreams = DreamSystem.GetRecentDreams(48);

        var groups = recentDreams.GroupBy(d => d.Symbol).Where(g => g.Count() >= 3).ToList();

        foreach (var group in groups)
        {
            if (Convergences.Any(c => c.Symbol == group.Key))
                continue;

            var convergence = new DreamConvergence
            {
                Symbol = group.Key,
                Count = group.Count(),
                Dreamers = group.Select(d => d.Dreamer).Distinct().ToList(),
                BecameMyth = false
            };

            Convergences.Add(convergence);
            Console.WriteLine($"\uD83D\uDD01 Converg\u00eancia: {group.Key} apareceu em {group.Count()} sonhos!");
        }
    }
}
