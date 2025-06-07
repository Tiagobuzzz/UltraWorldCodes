using UltraWorldAI.Psychology;
using Xunit;

public class LoyaltyReversalSystemTests
{
    [Fact]
    public void ChangeSideAddsRecord()
    {
        LoyaltyReversalSystem.History.Clear();
        LoyaltyReversalSystem.ChangeSide("Kael", "A", "B", "mentira");
        Assert.Single(LoyaltyReversalSystem.History);
    }
}
