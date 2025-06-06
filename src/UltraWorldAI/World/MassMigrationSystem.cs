using System.Linq;

namespace UltraWorldAI.World;

/// <summary>
/// Handles large scale population migrations between settlements.
/// </summary>
public static class MassMigrationSystem
{
    private static readonly System.Random Rand = new();

    /// <summary>
    /// Moves a portion of the population from one region to another.
    /// </summary>
    public static void TriggerMigration(string fromRegion, string toRegion, int amount)
    {
        var from = RaceSettlementDistributor.Settlements.FirstOrDefault(s => s.Region == fromRegion);
        var to = RaceSettlementDistributor.Settlements.FirstOrDefault(s => s.Region == toRegion);
        if (from == null || to == null) return;
        var migrating = System.Math.Min(amount, from.Population);
        if (migrating <= 0) return;
        from.Population -= migrating;
        to.Population += migrating;
        SettlementHistoryTracker.Register(from.Name, "Êxodo", $"{migrating} pessoas migraram para {to.Name}");
    }

    /// <summary>
    /// Randomly migrates a fraction of the population to a nearby settlement.
    /// </summary>
    public static void RandomMigration(string region)
    {
        var from = RaceSettlementDistributor.Settlements.FirstOrDefault(s => s.Region == region);
        if (from == null || from.Population < 10) return;
        var destinations = RaceSettlementDistributor.Settlements.Where(s => s.Region != region).ToList();
        if (destinations.Count == 0) return;
        var to = destinations[Rand.Next(destinations.Count)];
        var amount = from.Population / 10;
        TriggerMigration(region, to.Region, amount);
    }
}
