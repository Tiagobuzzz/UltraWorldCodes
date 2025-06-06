using UltraWorldAI.Economy;
using Xunit;

public class StockMarketSystemTests
{
    [Fact]
    public void TickFluctuatesPrice()
    {
        StockMarketSystem.RegisterStock("UWC", 10.0);
        var before = StockMarketSystem.GetPrice("UWC");
        StockMarketSystem.Tick();
        var after = StockMarketSystem.GetPrice("UWC");
        Assert.NotEqual(before, after);
    }
}
