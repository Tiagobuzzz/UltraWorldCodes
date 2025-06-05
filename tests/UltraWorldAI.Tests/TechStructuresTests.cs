using UltraWorldAI.Structures;
using Xunit;

public class TechStructuresTests
{
    [Fact]
    public void CreateStructureRegistersStructure()
    {
        TechStructures.AllStructures.Clear();
        var structure = TechStructures.CreateStructure("Tec1", "Bob", "Regiao", "Torre", "esperança");

        Assert.Single(TechStructures.AllStructures);
        Assert.Equal("Torre de Tec1", structure.Name);
    }
}
