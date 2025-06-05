using System.Linq;
using UltraWorldAI.Civilization;
using UltraWorldAI.World;
using Xunit;

public class SettlementSystemsTests
{
    [Fact]
    public void AISpawnCreatesSettlement()
    {
        RaceRepository.CreateDefaults();
        RaceCultureSystem.GenerateAll();
        IA_RaceLinker.Beings.Clear();
        RaceSettlementDistributor.Settlements.Clear();
        SettlementHistoryTracker.Events.Clear();

        IA_RaceLinker.CreateBeing("Teste", "Humanos");
        var ia = IA_RaceLinker.Beings.First();

        AISettlementInteraction.Act(ia);

        Assert.Single(RaceSettlementDistributor.Settlements);
        Assert.Contains(SettlementHistoryTracker.Events, e => e.EventType == "Fundação");
    }

    [Fact]
    public void CulturalEvolutionChangesSummary()
    {
        var settlement = new Settlement { Name = "Villa", CultureSummary = "Neutra" };
        SettlementHistoryTracker.Events.Clear();

        for (int i = 0; i < 100 && settlement.CultureSummary == "Neutra"; i++)
            CulturalEvolutionEngine.TickCulture(settlement);

        Assert.NotEqual("Neutra", settlement.CultureSummary);
        Assert.NotEmpty(SettlementHistoryTracker.Events);
    }

    [Fact]
    public void SettlementFusionCreatesUnion()
    {
        RaceSettlementDistributor.Settlements.Clear();
        SettlementHistoryTracker.Events.Clear();

        RaceSettlementDistributor.Settlements.AddRange(new[]
        {
            new Settlement { Name = "A", Region = "X", Race = "Humanos", Population = 10 },
            new Settlement { Name = "B", Region = "X", Race = "Humanos", Population = 5 }
        });

        for (int i = 0; i < 20 && RaceSettlementDistributor.Settlements.Count > 1; i++)
            SettlementFusionSystem.AttemptFusion();

        Assert.Single(RaceSettlementDistributor.Settlements);
        Assert.Equal(15, RaceSettlementDistributor.Settlements[0].Population);
        Assert.Contains(SettlementHistoryTracker.Events, e => e.EventType == "Fusão");
    }

    [Fact]
    public void PromoteCivilizationTriggersEvent()
    {
        var settlement = new Settlement
        {
            Name = "Confed",
            Region = "Z",
            Race = "Humanos",
            CultureSummary = "Confederação Cultural",
            Population = 6000
        };
        SettlementHistoryTracker.Events.Clear();

        SettlementFusionSystem.PromoteCivilization(settlement);

        Assert.Equal("Civilização Global Emergente", settlement.CultureSummary);
        Assert.Contains(SettlementHistoryTracker.Events, e => e.EventType == "Ascensão Civilizacional");
    }
}
