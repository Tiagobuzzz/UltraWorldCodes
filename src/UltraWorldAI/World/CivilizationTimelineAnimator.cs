using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.World;

public class WorldSnapshot
{
    public int Year { get; set; }
    public List<string> ActiveCivilizations { get; set; } = new();
}

public static class CivilizationTimelineAnimator
{
    public static List<WorldSnapshot> Timeline { get; } = new();

    public static void CaptureYear(int year)
    {
        var civs = RaceSettlementDistributor.Settlements
            .Where(s => s.Population > 500)
            .Select(s => $"{s.Name} ({s.Race})")
            .ToList();

        Timeline.Add(new WorldSnapshot
        {
            Year = year,
            ActiveCivilizations = civs
        });
    }

    public static void PlayTimeline()
    {
        foreach (var snapshot in Timeline.OrderBy(s => s.Year))
        {
            Console.WriteLine($"\n📅 Ano {snapshot.Year}");
            foreach (var civ in snapshot.ActiveCivilizations)
                Console.WriteLine($"🏙️ {civ}");
        }
    }
}
