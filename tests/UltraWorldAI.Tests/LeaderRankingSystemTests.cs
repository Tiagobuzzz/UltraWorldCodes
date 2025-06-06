using UltraWorldAI.Politics;
using Xunit;

public class LeaderRankingSystemTests
{
    [Fact]
    public void GetTopOrdersByInfluence()
    {
        LeaderRankingSystem.Register("A", 1);
        LeaderRankingSystem.Register("B", 3);
        var list = LeaderRankingSystem.GetTop(2);
        Assert.Equal("B", list[0]);
        Assert.Equal("A", list[1]);
    }
}
