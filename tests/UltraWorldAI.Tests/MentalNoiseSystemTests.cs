using UltraWorldAI.Module16;
using Xunit;

public class MentalNoiseSystemTests
{
    [Fact]
    public void EmitThoughtAddsPulse()
    {
        MentalNoiseSystem.ThoughtStream.Clear();
        MentalNoiseSystem.EmitThought("Elira", "Culpa", 3.5f, "Templo");
        Assert.Contains(MentalNoiseSystem.ThoughtStream, p => p.SourceAI == "Elira");
    }

    [Fact]
    public void TrySpawnEntityCreatesEntity()
    {
        MentalNoiseSystem.ThoughtStream.Clear();
        CollectiveEntitySystem.Entities.Clear();
        MentalNoiseSystem.EmitThought("Elira", "Medo", 6f, "Ruinas");
        MentalNoiseSystem.EmitThought("Kael", "Medo", 5f, "Ruinas");
        CollectiveEntitySystem.TrySpawnEntity("Ruinas");
        Assert.NotEmpty(CollectiveEntitySystem.Entities);
    }

    [Fact]
    public void ReactToNoiseStoresReaction()
    {
        MentalNoiseSystem.ThoughtStream.Clear();
        CognitiveOverloadSystem.Reactions.Clear();
        MentalNoiseSystem.EmitThought("Sarel", "Raiva", 7f, "Praia");
        CognitiveOverloadSystem.ReactToNoise("Sarel", "Praia");
        Assert.Contains(CognitiveOverloadSystem.Reactions, r => r.AI == "Sarel");
    }
}
