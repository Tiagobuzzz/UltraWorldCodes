using UltraWorldAI;
using UltraWorldAI.World;
using UltraWorldAI.History;
using Xunit;

public class PrehistoricWorldInitializerTests
{
    [Fact]
    public void InitializeClearsKnowledgeAndRegistersEra()
    {
        var p = new Person("Tester");
        p.Mind.Memory.AddMemory("old", 0.5f);
        p.Mind.Knowledge.LearnFact("a", "b", 1f);

        PrehistoricWorldInitializer.Initialize(p);

        Assert.Empty(p.Mind.Memory.Memories);
        Assert.Empty(p.Mind.Knowledge.Facts);
        Assert.Single(TechTimelineSystem.Eras);
        Assert.Contains("Pré-Pedra", TechTimelineSystem.Eras[0].Name);
    }
}
