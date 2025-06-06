using System.Collections.Generic;
using UltraWorldAI.Doctrine;
using Xunit;

public class DoctrinalMarketSystemTests
{
    [Fact]
    public void ApplyDoctrineStoresPolicy()
    {
        DoctrinalMarketSystem.Policies.Clear();
        DoctrinalMarketSystem.ApplyDoctrine(
            "Aurora",
            "Caminho do Valor Interno",
            new List<string> { "Ouro" },
            new List<string> { "Trigo" },
            0.15);

        Assert.Single(DoctrinalMarketSystem.Policies);
        var policy = DoctrinalMarketSystem.Policies[0];
        Assert.Equal("Aurora", policy.Culture);
        Assert.Contains("Ouro", policy.BannedProducts);
    }

    [Fact]
    public void SacredGoodsHaveNoTax()
    {
        DoctrinalMarketSystem.Policies.Clear();
        DoctrinalMarketSystem.ApplyDoctrine(
            "Aurora",
            "Caminho",
            new List<string>(),
            new List<string> { "Trigo" },
            0.2);

        var rate = DoctrinalMarketSystem.GetTaxRate("Aurora", "Trigo");
        Assert.Equal(0.0, rate);
    }
}
