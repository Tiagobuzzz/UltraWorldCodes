using System;
using System.Linq;
using UltraWorldAI.Civilization;

namespace UltraWorldAI.World;

public static class AISettlementInteraction
{
    private static readonly Random Rand = new();

    public static void Act(SapientBeing ia)
    {
        var near = RaceSettlementDistributor.Settlements.FirstOrDefault(s => s.Region == ia.CurrentRegion);
        if (near == null)
        {
            string newName = $"{ia.Name}-Fundacao";
            RaceSettlementDistributor.Settlements.Add(new Settlement
            {
                Name = newName,
                Region = ia.CurrentRegion,
                Race = ia.Race,
                CultureSummary = RaceCultureSystem.GetForRace(ia.Race)?.SocialStructure ?? "Tribo",
                Population = 1
            });
            SettlementHistoryTracker.Register(newName, "Fundação", $"Fundado por {ia.Name}");
            return;
        }

        near.Population += 1;
        if (near.Population > 1000 && Rand.NextDouble() < 0.1)
        {
            near.Population /= 3;
            SettlementHistoryTracker.Register(near.Name, "Colapso", "Colapso populacional por estresse social");
        }
    }
}
