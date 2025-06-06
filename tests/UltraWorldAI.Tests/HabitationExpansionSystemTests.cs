using UltraWorldAI.Territory;
using UltraWorldAI.World;
using Xunit;

public class HabitationExpansionSystemTests
{
    [Fact]
    public void BuildHousingIncreasesUnits()
    {
        var settlement = new Settlement { Name = "Camp", HousingUnits = 1 };
        HabitationExpansionSystem.BuildHousing(settlement, 5);
        Assert.Equal(6, settlement.HousingUnits);
    }

    [Fact]
    public void ExpandTerritoryClaimsRegion()
    {
        var settlement = new Settlement { Name = "Camp" };
        HabitationExpansionSystem.ExpandTerritory(settlement, "Nova Regiao");
        Assert.Contains(TerritoryClaimSystem.Claims, c => c.RegionName == "Nova Regiao" && c.ClaimedBy == settlement.Name);
    }
}
