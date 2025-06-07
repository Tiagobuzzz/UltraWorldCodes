using System.Collections.Generic;
using UltraWorldAI.DivineWorld;
using Xunit;

public class CosmologyCreationSystemTests
{
    [Fact]
    public void CreateEntityAddsToList()
    {
        CosmologyCreationSystem.Entities.Clear();
        CosmologyCreationSystem.CreateEntity("Nyara", "Guardi\u00e3o", "Sonhos", "Mem\u00f3ria");
        Assert.Single(CosmologyCreationSystem.Entities);
        Assert.Equal("Nyara", CosmologyCreationSystem.Entities[0].Name);
    }

    [Fact]
    public void CreatePlaneRegistersPlane()
    {
        CosmologyCreationSystem.Planes.Clear();
        CosmologyCreationSystem.CreatePlane("N\u00e9voa", "On\u00edrico", new List<string> { "Tempo" });
        Assert.Single(CosmologyCreationSystem.Planes);
        Assert.Equal("N\u00e9voa", CosmologyCreationSystem.Planes[0].Name);
    }
}

