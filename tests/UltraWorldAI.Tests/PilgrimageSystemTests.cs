using UltraWorldAI.Religion;
using Xunit;

public class PilgrimageSystemTests
{
    [Fact]
    public void AddArtifactRegistersArtifactAndSite()
    {
        PilgrimageSystem.Artifacts.Clear();
        PilgrimageSystem.PilgrimageSites.Clear();
        var artifact = PilgrimageSystem.AddArtifact("Olho Divino", "Monte", true);
        PilgrimageSystem.RegisterSite("Monte");

        Assert.Single(PilgrimageSystem.Artifacts);
        Assert.Contains("Monte", PilgrimageSystem.PilgrimageSites);
        Assert.True(artifact.IsTechHeresy);
    }
}
