using UltraWorldAI.DivineWorld;
using Xunit;

public class WorldShapingSystemTests
{
    [Fact]
    public void CreateGeographyRegistersElement()
    {
        WorldShapingSystem.CreatedElements.Clear();
        WorldShapingSystem.CreateGeography("Montanha", "Torre Infinita");
        Assert.Contains("Montanha: Torre Infinita", WorldShapingSystem.CreatedElements);
    }
}

