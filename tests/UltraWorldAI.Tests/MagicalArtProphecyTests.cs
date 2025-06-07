using UltraWorldAI.Module15;
using Xunit;

public class MagicalArtProphecyTests
{
    [Fact]
    public void EmbedProphecyStoresVision()
    {
        MagicalArtEffectSystem.Artworks.Clear();
        MagicalArtEffectSystem.CreateMagicalArt("Visao", "Ana", "Pintura", "Luz", false);
        MagicalArtEffectSystem.EmbedProphecy("Visao", "Fim do mundo");
        var vision = MagicalArtEffectSystem.RevealProphecy("Visao");
        Assert.Equal("Fim do mundo", vision);
    }
}
