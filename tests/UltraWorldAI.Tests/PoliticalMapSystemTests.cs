using UltraWorldAI.Territory;
using Xunit;

public class PoliticalMapSystemTests
{
    [Fact]
    public void AssignRegionRegistersTerritory()
    {
        PoliticalMapSystem.Regions.Clear();
        PoliticalMapSystem.AssignRegion("Vales", "Kael", "Selena", false);
        Assert.Contains(PoliticalMapSystem.Regions, r => r.Name == "Vales" && !r.IsDisputed);
    }
}
