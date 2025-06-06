using System.Collections.Generic;
using UltraWorldAI.World.Creation;
using Xunit;

public class MythicWorldSystemsTests
{
    [Fact]
    public void SpawnMegafaunaAddsCreature()
    {
        MythicMegafaunaSystem.Creatures.Clear();
        MythicMegafaunaSystem.SpawnMegafauna("Baleia", "Oceano", "Enorme", "Fogo", false);
        Assert.Single(MythicMegafaunaSystem.Creatures);
        Assert.Equal("Baleia", MythicMegafaunaSystem.Creatures[0].Name);
    }

    [Fact]
    public void CreateRuinAddsRuin()
    {
        LivingRuinsSystem.Ruins.Clear();
        LivingRuinsSystem.CreateRuin("Cidade", "Vale", true, "Mítica");
        Assert.Single(LivingRuinsSystem.Ruins);
        Assert.True(LivingRuinsSystem.Ruins[0].IsConscious);
    }

    [Fact]
    public void DriftMovesContinent()
    {
        ContinentalDriftSystem.Continents.Clear();
        ContinentalDriftSystem.CreateContinent("Lemuria", 0, 0, new List<string> { "Terra" });
        ContinentalDriftSystem.Drift("Lemuria", 3, -1);
        Assert.Equal(3, ContinentalDriftSystem.Continents[0].PosX);
        Assert.Equal(-1, ContinentalDriftSystem.Continents[0].PosY);
    }
}
