using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.Economy;
using Xunit;

public class PhilosophySpreadSystemTests
{
    [Fact]
    public void PropagateIncreasesInfluence()
    {
        PhilosophySpreadSystem.InfluenceMap.Clear();
        PhilosophySpreadSystem.PropagateToCulture("Escola", "Aurora", 30);
        PhilosophySpreadSystem.PropagateToCulture("Escola", "Aurora", 80);
        var entry = PhilosophySpreadSystem.InfluenceMap.First(f => f.Culture == "Aurora");
        Assert.Equal(100, entry.InfluenceLevel);
    }

    [Fact]
    public void SpreadByMissionaryAddsCultures()
    {
        PhilosophySpreadSystem.InfluenceMap.Clear();
        PhilosophySpreadSystem.SpreadByMissionary("Escola", new List<string> { "Umbra", "Cinzentos" }, 20);
        Assert.Equal(2, PhilosophySpreadSystem.InfluenceMap.Count);
    }
}
