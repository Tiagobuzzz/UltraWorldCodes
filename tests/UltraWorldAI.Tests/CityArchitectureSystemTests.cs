using UltraWorldAI.World;
using Xunit;

public class CityArchitectureSystemTests
{
    [Fact]
    public void SetStyleChangesSettlementProperty()
    {
        var settlement = new Settlement { Name = "Town" };
        CityArchitectureSystem.SetStyle(settlement, "Barroco");
        Assert.Equal("Barroco", settlement.ArchitectureStyle);
        Assert.Equal("Barroco", CityArchitectureSystem.GetStyle(settlement));
    }
}
