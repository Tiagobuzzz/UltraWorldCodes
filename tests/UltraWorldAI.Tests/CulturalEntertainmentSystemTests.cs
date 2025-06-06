using UltraWorldAI;
using Xunit;

public class CulturalEntertainmentSystemTests
{
    [Fact]
    public void AddMediaStoresEntry()
    {
        CulturalEntertainmentSystem.AddMedia("A", "música");
        var list = CulturalEntertainmentSystem.GetMedia("A");
        Assert.Contains("música", list);
    }
}

