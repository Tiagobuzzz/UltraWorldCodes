using System.Collections.Generic;
using System.Linq;
using System;

namespace UltraWorldAI.Philosophy;

public static class PhilosophyRankingSystem
{
    public static List<Philosophy> GetTop(int count)
    {
        return PhilosophySeed.AllPhilosophies
            .OrderByDescending(p => p.InfluenceLevel)
            .Take(count)
            .ToList();
    }

    public static void PrintRanking()
    {
        int rank = 1;
        foreach (var p in GetTop(PhilosophySeed.AllPhilosophies.Count))
            Console.WriteLine($"{rank++}. {p.Name} - {p.InfluenceLevel:0.00}");
    }
}
