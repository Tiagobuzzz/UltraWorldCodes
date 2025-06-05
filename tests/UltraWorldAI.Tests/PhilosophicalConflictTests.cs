using UltraWorldAI.Philosophy;
using Xunit;

public class PhilosophicalConflictTests
{
    [Fact]
    public void ResolveClashDeterminesWinner()
    {
        PhilosophySeed.AllPhilosophies.Clear();
        var pa = PhilosophySeed.CreatePhilosophy("A", "dor");
        var pb = PhilosophySeed.CreatePhilosophy("B", "memória");
        pa.InfluenceLevel = 0.8f;
        pb.InfluenceLevel = 0.5f;
        var clash = PhilosophicalConflict.StartClash(pa, pb, "teste");
        PhilosophicalConflict.ResolveClash(clash);
        Assert.True(clash.IsResolved);
        Assert.Contains(pa.Name, clash.Outcome);
    }
}
