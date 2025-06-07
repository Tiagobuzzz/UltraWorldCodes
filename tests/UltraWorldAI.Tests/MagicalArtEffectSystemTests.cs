using UltraWorldAI.Module15;
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
}
