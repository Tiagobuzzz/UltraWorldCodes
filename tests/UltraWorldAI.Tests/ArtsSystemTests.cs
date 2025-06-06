using UltraWorldAI.Arts;
using Xunit;

public class ArtsSystemTests
{
    [Fact]
    public void AddArtStoresPiece()
    {
        ArtsSystem.AddArt("A", new ArtPiece { Type = "música", Title = "Canção", Creator = "X" });
        var arts = ArtsSystem.GetArts("A");
        Assert.Contains(arts, a => a.Title == "Canção");
    }
}
