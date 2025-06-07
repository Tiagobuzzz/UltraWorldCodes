using System.Collections.Generic;
using UltraWorldAI;
using UltraWorldAI.DivineWorld;
using UltraWorldAI.Religion;
using UltraWorldAI.World;
using UltraWorldAI.Time;
using Xunit;

public class DivineIntegrationSystemTests
{
    [Fact]
    public void BlessPopulationUpdatesModules()
    {
        var cultureSystem = new CultureSystem();
        var philosophy = new PhilosophySystem();
        var culture = cultureSystem.CreateCultureFromIdea("Teste", new List<string>{"Valor"});

        ReligionSystem.Religions.Clear();
        WorldMap.Landmarks.Clear();
        AIBehavior.AvoidedZones.Clear();
        EraTimelineSystem.Eras.Clear();

        var god = GodFactory.CreateGod("Nyara", DivineDomain.Silencio, DivineTemperament.Dual);
        DivineIntegrationSystem.BlessPopulation(god, cultureSystem, philosophy, culture.Name, "Zarthis");

        Assert.Contains(culture.CoreValues, v => v.Contains("protege"));
        Assert.Single(ReligionSystem.Religions);
        Assert.Contains(WorldMap.Landmarks, l => l.Contains("Nyara"));
        Assert.Contains($"Templo de {god.Name}", AIBehavior.AvoidedZones.Keys);
        Assert.NotEmpty(EraTimelineSystem.Eras);
    }
}
