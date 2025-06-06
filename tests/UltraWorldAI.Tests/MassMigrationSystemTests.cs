using UltraWorldAI.World;
using Xunit;

public class MassMigrationSystemTests
{
    [Fact]
    public void TriggerMigrationMovesPopulation()
    {
        RaceSettlementDistributor.Settlements.Clear();
        var from = new Settlement { Name = "A", Region = "R1", Population = 100 };
        var to = new Settlement { Name = "B", Region = "R2", Population = 50 };
        RaceSettlementDistributor.Settlements.Add(from);
        RaceSettlementDistributor.Settlements.Add(to);

        MassMigrationSystem.TriggerMigration("R1", "R2", 30);

        Assert.Equal(70, from.Population);
        Assert.Equal(80, to.Population);
        Assert.Contains(SettlementHistoryTracker.Events, h => h.SettlementName == "A" && h.EventType == "Êxodo");
    }
}
