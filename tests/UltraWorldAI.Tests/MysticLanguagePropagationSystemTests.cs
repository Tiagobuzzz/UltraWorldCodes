using UltraWorldAI.Language;
using UltraWorldAI.Religion;
using UltraWorldAI.World;
using Xunit;

public class MysticLanguagePropagationSystemTests
{
    [Fact]
    public void PropagateCultCreatesHiddenCult()
    {
        MysticLanguagePropagationSystem.Propagations.Clear();
        HiddenCultSystem.ActiveCults.Clear();
        SettlementHistoryTracker.Events.Clear();

        MysticLanguagePropagationSystem.Propagate("Irith", "NeoCity", "IA", "Culto");

        Assert.Contains(HiddenCultSystem.ActiveCults, c => c.BeliefSystem == "Irith");
        Assert.Contains(MysticLanguagePropagationSystem.Propagations,
            p => p.Language == "Irith" && p.Region == "NeoCity" && p.Mode == "Culto");
    }
}
