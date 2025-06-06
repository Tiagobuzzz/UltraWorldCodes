using UltraWorldAI.Economy;
using Xunit;

public class TradeCareerSystemTests
{
    [Fact]
    public void CryptoMarketSimulationChangesValue()
    {
        TradeCareerSystem.Cryptocurrencies.Clear();
        TradeCareerSystem.RegisterCryptocurrency("BitGem", 10);
        var before = TradeCareerSystem.Cryptocurrencies[0].Value;
        TradeCareerSystem.SimulateCryptoMarket();
        var after = TradeCareerSystem.Cryptocurrencies[0].Value;
        Assert.NotEqual(before, after);
    }
}
