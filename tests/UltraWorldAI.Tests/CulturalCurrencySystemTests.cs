using UltraWorldAI.Economy;
using Xunit;

public class CulturalCurrencySystemTests
{
    [Fact]
    public void DefineCurrencyStoresEntry()
    {
        CulturalCurrencySystem.Currencies.Clear();
        CulturalCurrencySystem.DefineCurrency("Umbra", "Fragmento", "Pedra", 1.2);
        Assert.Single(CulturalCurrencySystem.Currencies);
        var c = CulturalCurrencySystem.Currencies[0];
        Assert.Equal("Umbra", c.Culture);
        Assert.Equal("Fragmento", c.CurrencyName);
    }
}
