using UltraWorldAI;
using Xunit;

public class ReputationSystemTests
{
    [Fact]
    public void AdjustAndRetrieveWorks()
    {
        var rep = new ReputationSystem();
        rep.AdjustReputation("hero", 0.5f);
        rep.AdjustReputation("hero", 0.3f);
        Assert.Equal(0.8f, rep.GetReputation("hero"), 2);
        rep.AdjustReputation("traitor", -0.4f);
        Assert.Equal(-0.4f, rep.GetReputation("traitor"), 2);
    }
}
