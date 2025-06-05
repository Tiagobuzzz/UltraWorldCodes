using System.Collections.Generic;
using UltraWorldAI.Discovery;
using Xunit;

public class TechLoreSystemTests
{
    [Fact]
    public void GenerateLoreReturnsText()
    {
        TechCreator.TechPool.Clear();
        var tech = TechCreator.CreateTech("X", new List<string> { "fogo" });
        var lore = TechLoreSystem.GenerateLore(tech);
        Assert.Contains("Lenda de", lore);
    }
}
