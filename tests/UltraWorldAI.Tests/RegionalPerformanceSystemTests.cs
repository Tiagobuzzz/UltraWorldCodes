using System.Collections.Generic;
using UltraWorldAI.Module15;
using UltraWorldAI.World;
using Xunit;

public class RegionalPerformanceSystemTests
{
    [Fact]
    public void OrganizeAddsPerformanceAndImpact()
    {
        RegionalPerformanceSystem.Performances.Clear();
        WorldImpactSystem.Impacts.Clear();
        RegionalPerformanceSystem.Organize("Festival", new List<string>{"Grupo"}, "Vale", "Alegria");
        Assert.Contains(RegionalPerformanceSystem.Performances, p => p.Title == "Festival" && p.Region == "Vale");
        Assert.Contains(WorldImpactSystem.Impacts, i => i.TechName == "Festival" && i.Region == "Vale");
    }
}
