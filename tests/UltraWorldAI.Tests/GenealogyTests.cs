using UltraWorldAI.Civilization;
using Xunit;

public class GenealogyTests
{
    [Fact]
    public void AddDescendantCreatesNode()
    {
        var race = new SapientRace { Name = "Test", GenealogyRoot = new GenealogyNode { Name = "Root" } };
        race.GenealogyRoot.AddDescendant("Root", "Child");
        var found = race.GenealogyRoot.Find("Child");
        Assert.NotNull(found);
        Assert.Equal("Child", found!.Name);
    }
}
