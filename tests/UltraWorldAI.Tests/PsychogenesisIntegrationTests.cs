using System.Linq;
using UltraWorldAI;
using UltraWorldAI.Health;
using UltraWorldAI.World;
using UltraWorldAI.Visualization;
using Xunit;

public class PsychogenesisIntegrationTests
{
    public PsychogenesisIntegrationTests()
    {
        PsychogenesisSystem.Reset();
        BeliefTerrainSystem.Reset();
        FaithDiseaseSystem.Reset();
        InteractionVisualizer.Log.Clear();
    }

    [Fact]
    public void BeliefManifestationAltersRegionAndCuresDisease()
    {
        FaithDiseaseSystem.AddDisease("Febre Sagrada", "A Lua Purifica");
        PsychogenesisSystem.RegisterBelief("Zayara", "A Lua Purifica", 0.5f);
        PsychogenesisSystem.RegisterBelief("Zayara", "A Lua Purifica", 0.4f);
        Assert.Equal("A Lua Purifica", BeliefTerrainSystem.GetRegionBelief("Zayara"));
        Assert.True(FaithDiseaseSystem.Diseases.First().Cured);
    }

    [Fact]
    public void OverloadTriggersAfterManyManifestations()
    {
        for (int i = 0; i < 4; i++)
            PsychogenesisSystem.RegisterBelief("Excesso", $"Crenca{i}", 0.9f);

        var count = PsychogenesisSystem.ActiveBeliefs.Count(b => b.Culture == "Excesso" && b.Manifested);
        Assert.Equal(4, count);
    }
}
