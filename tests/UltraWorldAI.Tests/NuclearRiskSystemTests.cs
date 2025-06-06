using UltraWorldAI.World;
using Xunit;

public class NuclearRiskSystemTests
{
    [Fact]
    public void TickChangesRiskLevel()
    {
        var before = NuclearRiskSystem.GetRiskLevel();
        NuclearRiskSystem.Tick();
        var after = NuclearRiskSystem.GetRiskLevel();
        Assert.NotEqual(before, after);
    }
}
