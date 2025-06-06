using UltraWorldAI.Politics;
using Xunit;

public class DynasticMythosSystemTests
{
    [Fact]
    public void DeclareMythStoresLegend()
    {
        DynasticMythosSystem.Legends.Clear();
        DynasticMythosSystem.DeclareMyth("Umbra", "Lua Negra", true, true);
        Assert.Contains(DynasticMythosSystem.Legends, m => m.HouseName == "Umbra" && m.IsRevered);
    }
}
