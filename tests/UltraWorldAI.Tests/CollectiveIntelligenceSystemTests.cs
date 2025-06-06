using System.Collections.Generic;
using UltraWorldAI.Society;
using Xunit;

public class CollectiveIntelligenceSystemTests
{
    [Fact]
    public void DecideReturnsMajorityChoice()
    {
        var decision = CollectiveIntelligenceSystem.Decide(
            new[] { "A", "B" },
            new List<string> { "B", "B", "A" });
        Assert.Equal("B", decision);
    }
}
