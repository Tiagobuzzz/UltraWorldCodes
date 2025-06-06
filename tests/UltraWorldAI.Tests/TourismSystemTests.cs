using UltraWorldAI.Economy;
using Xunit;

public class TourismSystemTests
{
    [Fact]
    public void VisitAccumulatesRevenue()
    {
        TourismSystem.Spots.Clear();
        TourismSystem.RegisterSpot("Beach");
        TourismSystem.Visit("Beach", 10, 5);
        Assert.Equal(50, TourismSystem.Spots[0].Revenue);
    }
}
