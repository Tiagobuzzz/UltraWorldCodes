using System.Collections.Generic;
using UltraWorldAI.Discovery;
using Xunit;

public class TechEvolutionTests
{
    [Fact]
    public void IterateTechAddsIteration()
    {
        TechCreator.TechPool.Clear();
        var baseTech = TechCreator.CreateTech("IA", new List<string> { "fogo" });
        var evolved = TechEvolution.IterateTech(baseTech, "metal");

        Assert.NotEqual(baseTech.Name, evolved.Name);
        Assert.Contains(evolved, TechEvolution.EvolutionMap[baseTech.Name].Iterations);
    }
}
