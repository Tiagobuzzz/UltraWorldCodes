using UltraWorldAI.Module15;
using Xunit;

public class ArtisticExpressionSystemTests
{
    [Fact]
    public void CreateWorkAddsArtwork()
    {
        ArtisticExpressionSystem.Artworks.Clear();
        ArtisticExpressionSystem.CreateWork("Ana", "Pintura", "Luz", 0.7f);
        Assert.Contains(ArtisticExpressionSystem.Artworks, a => a.Author == "Ana" && a.Medium == "Pintura");
    }
}
