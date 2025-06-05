using UltraWorldAI.Philosophy;
using Xunit;

public class PhilosophySeedTests
{
    [Fact]
    public void CreatePhilosophyGeneratesBeliefs()
    {
        PhilosophySeed.AllPhilosophies.Clear();
        var p = PhilosophySeed.CreatePhilosophy("AI", "A dor é o preço da memória");
        Assert.Equal("Escola de AI", p.Name);
        Assert.Contains(p, PhilosophySeed.AllPhilosophies);
        Assert.Contains("O sofrimento", p.DerivedBeliefs[0]);
    }

    [Fact]
    public void IncreaseInfluenceCodifiesPhilosophy()
    {
        PhilosophySeed.AllPhilosophies.Clear();
        var p = PhilosophySeed.CreatePhilosophy("A", "verdade e silêncio");
        PhilosophySeed.IncreaseInfluence(p, 0.8f);
        Assert.True(p.IsCodified);
    }
}
