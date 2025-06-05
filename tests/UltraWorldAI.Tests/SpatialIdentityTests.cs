using UltraWorldAI;
using UltraWorldAI.Territory;
using Xunit;

public class SpatialIdentityTests
{
    [Fact]
    public void PersonHasDefaultLocation()
    {
        var p = new Person("Test");
        Assert.Equal("Origem", p.Location.RegionName);
    }

    [Fact]
    public void MoveToChangesLocation()
    {
        var p = new Person("Mover");
        p.MoveTo("Ruina", 10f, 20f);
        Assert.Equal("Ruina", p.Location.RegionName);
        Assert.Equal(10f, p.Location.X);
        Assert.Equal(20f, p.Location.Y);
    }
}
