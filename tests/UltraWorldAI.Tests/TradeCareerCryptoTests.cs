using UltraWorldAI.Economy;
using Xunit;

public class TradeCareerCryptoTests
{
    [Fact]
    public void MarketUpdateChangesValue()
    {
        TradeCareerSystem.Cryptocurrencies.Clear();
        TradeCareerSystem.RegisterCryptocurrency("FicCoin", 10.0, 0.5);
        var before = TradeCareerSystem.Cryptocurrencies[0].Value;
        TradeCareerSystem.UpdateMarket();
        var after = TradeCareerSystem.Cryptocurrencies[0].Value;
        Assert.NotEqual(before, after);
    }
}
