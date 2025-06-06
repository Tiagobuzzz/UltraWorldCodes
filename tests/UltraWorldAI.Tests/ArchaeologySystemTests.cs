using UltraWorldAI;
using UltraWorldAI.World.Archaeology;
using Xunit;

public class ArchaeologySystemTests
{
    [Fact]
    public void ExplorationAddsMemory()
    {
        var ruin = RuinGenerator.Generate("Vale Perdido");
        var person = new Person("Explorer");
        var artifact = ArchaeologySystem.Explore(ruin, person);
        Assert.Contains("ruínas", person.Mind.Memory.Memories[0].Summary);
        Assert.Contains("Artefato", artifact);
    }
}
