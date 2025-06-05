using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CultureSystemTests
{
    [Fact]
    public void CreateCultureFromIdeaAddsCulture()
    {
        var system = new CultureSystem();
        system.CreateCultureFromIdea("Sabedoria", new List<string> { "Conhecimento", "Comunidade" });
        Assert.Single(system.Cultures);
        Assert.Equal("Cultura de Sabedoria", system.Cultures[0].Name);
    }

    [Fact]
    public void AbsorbLocalCultureUpdatesBeliefs()
    {
        var person = new Person("Cultural");
        var system = new CultureSystem();
        system.CreateCultureFromIdea("Forca", new List<string> { "Coragem" });
        system.AbsorbLocalCulture(person);
        Assert.Contains("Coragem", person.Mind.Beliefs.Beliefs.Keys);
    }
}
