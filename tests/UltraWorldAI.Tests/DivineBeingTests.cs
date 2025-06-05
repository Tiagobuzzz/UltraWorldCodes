using UltraWorldAI;
using UltraWorldAI.Territory;
using Xunit;

public class DivineBeingTests
{
    [Fact]
    public void InspireAddsBeliefAndMemory()
    {
        var god = new DivineBeing { Name = "Aureon" };
        var follower = new Person("Crente");

        god.Inspire(follower.Mind);

        Assert.Contains($"fé em {god.Name}", follower.Mind.Beliefs.Beliefs.Keys);
        Assert.Contains(follower.Mind.Memory.Memories, m => m.Summary.Contains(god.Name));
    }

    [Fact]
    public void BlessRegionMarksSacred()
    {
        var god = new DivineBeing { Name = "Aureon" };
        god.BlessRegion("Templo Antigo");
        Assert.True(SacredSpace.IsSacred("Templo Antigo"));
    }
}
