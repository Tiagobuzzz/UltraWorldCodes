using UltraWorldAI.Game;
using Xunit;

public class ChanceEventSystemTests
{
    [Fact]
    public void RollDiceReturnsWithinRange()
    {
        ChanceEventSystem.SetSeed(1);
        int value = ChanceEventSystem.RollDice(6);
        Assert.InRange(value, 1, 6);
    }

    [Fact]
    public void TriggerEventRespectsChance()
    {
        ChanceEventSystem.SetSeed(0);
        Assert.True(ChanceEventSystem.TriggerEvent("test", 100));
        Assert.False(ChanceEventSystem.TriggerEvent("test", 0));
    }
}
