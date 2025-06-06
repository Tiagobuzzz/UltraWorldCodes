using UltraWorldAI.Economy;
using Xunit;

public class CommodityMarketSystemTests
{
    [Fact]
    public void RegisterCommodityAddsPrice()
    {
        CommodityMarketSystem.RegisterCommodity("ouro", 10.0);
        Assert.Equal(10.0, CommodityMarketSystem.GetPrice("ouro"));
    }

    [Fact]
    public void TickMarketAltersPrice()
    {
        CommodityMarketSystem.RegisterCommodity("prata", 5.0);
        var before = CommodityMarketSystem.GetPrice("prata");
        CommodityMarketSystem.TickMarket();
        var after = CommodityMarketSystem.GetPrice("prata");
        Assert.NotEqual(before, after);
    }
}
