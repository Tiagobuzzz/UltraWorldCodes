using UltraWorldAI.Religion;
using UltraWorldAI.Territory;
using Xunit;

public class SacredSystemTests
{
    [Fact]
    public void CreateArtifactAndDesignateSiteWorks()
    {
        SacredSystem.Artifacts.Clear();
        SacredSystem.CreateArtifact("Chave", "Desperta o deus", "Templo");
        SacredSystem.DesignatePilgrimageSite("Lago", "Arkhim");

        Assert.Single(SacredSystem.Artifacts);
        Assert.True(SacredSpace.IsSacred("Arkhim"));
    }
}
