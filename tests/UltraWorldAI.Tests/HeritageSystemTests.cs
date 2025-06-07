using System.Collections.Generic;
using UltraWorldAI.Kinship;
using Xunit;

public class HeritageSystemTests
{
    [Fact]
    public void CreateProfileStoresTraits()
    {
        HeritageSystem.Profiles.Clear();
        HeritageSystem.CreateProfile(
            "Test",
            new() { { "Forca", 0.8f } },
            new() { "Cultura" },
            new() { "Marca" });
        var profile = HeritageSystem.Profiles["Test"];
        Assert.Contains("Cultura", profile.CulturalTraits);
    }
}
