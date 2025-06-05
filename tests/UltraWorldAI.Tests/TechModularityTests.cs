using System.Collections.Generic;
using UltraWorldAI.Discovery;
using Xunit;

public class TechModularityTests
{
    [Fact]
    public void CombineTechsAggregatesModules()
    {
        TechCreator.TechPool.Clear();
        var t1 = TechCreator.CreateTech("A", new List<string> { "fogo" });
        var t2 = TechCreator.CreateTech("A", new List<string> { "som" });
        var modular = TechModularity.CombineTechs("Mix", new List<ConceptualTech> { t1, t2 });

        Assert.Equal(2, modular.Modules.Count);
        Assert.Contains(t1.Name, modular.Modules);
    }
}
