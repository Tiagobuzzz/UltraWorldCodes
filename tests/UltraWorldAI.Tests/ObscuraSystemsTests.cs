using UltraWorldAI.Obscura;
using Xunit;

public class ObscuraSystemsTests
{
    [Fact]
    public void RegisterLocationAddsToList()
    {
        ForbiddenLocationSystem.Locations.Clear();
        ForbiddenLocationSystem.RegisterLocation("Sala do Inverso", "Espaço Invertido", "Esquecer o nome");
        Assert.Contains(ForbiddenLocationSystem.Locations, l => l.Name == "Sala do Inverso");
    }

    [Fact]
    public void ApplyEffectRegistersReaction()
    {
        CognitiveResonanceSystem.Reactions.Clear();
        CognitiveResonanceSystem.ApplyEffect("Kael", "Sala do Inverso");
        Assert.NotEmpty(CognitiveResonanceSystem.Reactions);
    }

    [Fact]
    public void RegisterStructureAddsEntry()
    {
        LivingArchitectureSystem.Structures.Clear();
        LivingArchitectureSystem.RegisterStructure("Templo", "Guardião", "Magia Geométrica", "Aceitar o esquecimento");
        Assert.Contains(LivingArchitectureSystem.Structures, s => s.Name == "Templo");
    }

    [Fact]
    public void AddCorridorCreatesCorridor()
    {
        NonEuclideanCorridorSystem.Corridors.Clear();
        NonEuclideanCorridorSystem.AddCorridor("Corredor Alfa", "Torção Infinita", "Retorna ao início");
        Assert.Contains(NonEuclideanCorridorSystem.Corridors, c => c.Name == "Corredor Alfa");
    }
}
