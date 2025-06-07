using UltraWorldAI.Politics;
using Xunit;

public class HouseWarSystemTests
{
    [Fact]
    public void DeclareWarAddsWar()
    {
        HouseWarSystem.Wars.Clear();
        HouseWarSystem.DeclareWar("A", "B", "Disputa");
        Assert.Contains(HouseWarSystem.Wars, w => w.HouseA == "A" && w.HouseB == "B");
    }
}
