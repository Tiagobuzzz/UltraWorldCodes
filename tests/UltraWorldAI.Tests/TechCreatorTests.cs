using System.Collections.Generic;
using UltraWorldAI.Discovery;
using Xunit;

public class TechCreatorTests
{
    [Fact]
    public void CreateTechStoresInPool()
    {
        TechCreator.TechPool.Clear();
        var tech = TechCreator.CreateTech("IA", new List<string> { "fogo", "ponta" });
        Assert.Single(TechCreator.TechPool);
        Assert.Contains("fogo", tech.CombinedConcepts);
        Assert.NotEqual(string.Empty, tech.Name);
    }
}
