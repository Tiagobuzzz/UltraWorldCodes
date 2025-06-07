using UltraWorldAI.Dreams;
using UltraWorldAI.World.Ecology;
using UltraWorldAI.World.Creation;
using Xunit;

public class DreamWorldSystemTests
{
    [Fact]
    public void RecordDreamAddsToListAndCreatesClimateEvent()
    {
        DreamSystem.AllDreams.Clear();
        ClimateEventSystem.Events.Clear();

        DreamSystem.RecordDream("A", "Vale", "Serpente", "Desejo", "Visao");

        Assert.Single(DreamSystem.AllDreams);
        Assert.Single(ClimateEventSystem.Events);
    }

    [Fact]
    public void ConvergenceDetectedAfterThreeDreams()
    {
        DreamSystem.AllDreams.Clear();
        DreamConvergenceSystem.Convergences.Clear();

        DreamSystem.RecordDream("A", "V1", "Chave", "Medo", "X");
        DreamSystem.RecordDream("B", "V1", "Chave", "Medo", "Y");
        DreamSystem.RecordDream("C", "V1", "Chave", "Medo", "Z");

        DreamConvergenceSystem.CheckConvergence();

        Assert.Single(DreamConvergenceSystem.Convergences);
        Assert.Equal("Chave", DreamConvergenceSystem.Convergences[0].Symbol);
    }

    [Fact]
    public void NightmareSpawnsMonster()
    {
        EcosystemGeneticSystem.Creatures.Clear();
        var dream = DreamSystem.RecordDream("A", "Floresta", "Bicho", "Medo", "Correndo");

        Assert.NotEmpty(EcosystemGeneticSystem.Creatures);
        Assert.Contains("Bicho", EcosystemGeneticSystem.Creatures[0].Name);
    }

    [Fact]
    public void MythGenerationStoresMyth()
    {
        MythFormationSystem.Myths.Clear();

        MythFormationSystem.GenerateMyth("Espada", "A", "Ordem", "Protecao");

        Assert.Single(MythFormationSystem.Myths);
        Assert.Equal("Espada", MythFormationSystem.Myths[0].Symbol);
    }
}
