using UltraWorldAI.Philosophy;
using Xunit;

public class PhilosophyRankingSystemTests
{
    [Fact]
    public void GetTopOrdersByInfluence()
    {
        PhilosophySeed.AllPhilosophies.Clear();
        var a = PhilosophySeed.CreatePhilosophy("A", "x");
        var b = PhilosophySeed.CreatePhilosophy("B", "y");
        PhilosophySeed.IncreaseInfluence(a, 0.2f);
        PhilosophySeed.IncreaseInfluence(b, 0.5f);

        var list = PhilosophyRankingSystem.GetTop(2);
        Assert.Equal(b, list[0]);
        Assert.Equal(a, list[1]);
    }
}
