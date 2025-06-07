using UltraWorldAI.Module15;
using UltraWorldAI.World;
using Xunit;

public class MagicalArtEffectSystemTests
{
    [Fact]
    public void CreateMagicalArtAddsArtwork()
    {
        MagicalArtEffectSystem.Artworks.Clear();
        MagicalArtEffectSystem.CreateMagicalArt("Obra", "Ana", "Escultura", "Curar", true);
        Assert.Contains(MagicalArtEffectSystem.Artworks, a => a.Title == "Obra" && a.Creator == "Ana" && a.RequiresRitual);
    }

    [Fact]
    public void ApplyEffectRecordsImpact()
    {
        MagicalArtEffectSystem.Artworks.Clear();
        WorldImpactSystem.Impacts.Clear();
        MagicalArtEffectSystem.CreateMagicalArt("Sopro", "Ana", "Pintura", "Chuva", false);
        MagicalArtEffectSystem.ApplyEffect("Sopro", "Vale");
        Assert.Contains(WorldImpactSystem.Impacts, i => i.TechName == "Sopro" && i.Region == "Vale");
    }
}
