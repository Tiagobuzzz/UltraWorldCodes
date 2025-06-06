using UltraWorldAI.World;
using Xunit;

public class ForcedCulturalMigrationTests
{
    [Fact]
    public void ForceCulturalMigrationMovesPopulation()
    {
        RaceSettlementDistributor.Settlements.Clear();
        var a = new Settlement { Name = "A", Region = "R1", CultureSummary = "C1", Population = 100 };
        var b = new Settlement { Name = "B", Region = "R2", CultureSummary = "C2", Population = 50 };
        RaceSettlementDistributor.Settlements.Add(a);
        RaceSettlementDistributor.Settlements.Add(b);

        MassMigrationSystem.ForceCulturalMigration("C1", "C2", 20);

        Assert.Equal(80, a.Population);
        Assert.Equal(70, b.Population);
        Assert.Contains(SettlementHistoryTracker.Events, e => e.EventType == "Exílio");
    }
}
