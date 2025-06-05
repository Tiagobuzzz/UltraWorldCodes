using UltraWorldAI.World;
using Xunit;

public class WorldImpactSystemTests
{
    [Fact]
    public void ApplyImpactStoresRecord()
    {
        WorldImpactSystem.Impacts.Clear();
        WorldImpactSystem.ApplyImpact("TecA", "Regiao", "clima");

        Assert.Single(WorldImpactSystem.Impacts);
        Assert.Equal("TecA", WorldImpactSystem.Impacts[0].TechName);
    }
}
