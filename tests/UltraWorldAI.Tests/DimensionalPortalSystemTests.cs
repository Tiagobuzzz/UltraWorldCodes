using UltraWorldAI.Magic;
using Xunit;

public class DimensionalPortalSystemTests
{
    [Fact]
    public void CreateRealmStoresRealm()
    {
        DimensionalPortalSystem.Realms.Clear();
        DimensionalPortalSystem.CreateRealm("X", "Y");
        Assert.Contains(DimensionalPortalSystem.Realms, r => r.Name == "X");
    }

    [Fact]
    public void CreatePortalStoresPortal()
    {
        DimensionalPortalSystem.Portals.Clear();
        DimensionalPortalSystem.CreatePortal("Loc", "Realm", true);
        Assert.Contains(DimensionalPortalSystem.Portals, p => p.Location == "Loc");
    }
}
