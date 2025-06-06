using UltraWorldAI.Economy;
using Xunit;

public class EconomicCorruptionSystemTests
{
    [Fact]
    public void CreateGuildAddsGuild()
    {
        EconomicCorruptionSystem.Guilds.Clear();
        EconomicCorruptionSystem.CreateGuild("L\u00e2minas", "Rel\u00edquias", false);
        Assert.Single(EconomicCorruptionSystem.Guilds);
        var g = EconomicCorruptionSystem.Guilds[0];
        Assert.Equal("L\u00e2minas", g.Name);
        Assert.Equal("Rel\u00edquias", g.Specialization);
        Assert.False(g.IsLegal);
    }

    [Fact]
    public void SetTaxAddsPolicy()
    {
        EconomicCorruptionSystem.Taxes.Clear();
        EconomicCorruptionSystem.SetTax("Umbra", "Ferro", 0.15);
        Assert.Single(EconomicCorruptionSystem.Taxes);
        var t = EconomicCorruptionSystem.Taxes[0];
        Assert.Equal("Umbra", t.Kingdom);
        Assert.Equal("Ferro", t.ResourceTaxed);
        Assert.Equal(0.15, t.Rate, 3);
    }

    [Fact]
    public void UpdateInflationAddsIndex()
    {
        EconomicCorruptionSystem.Inflation.Clear();
        EconomicCorruptionSystem.UpdateInflation("Fragmento", 0.32);
        Assert.Single(EconomicCorruptionSystem.Inflation);
        var idx = EconomicCorruptionSystem.Inflation[0];
        Assert.Equal("Fragmento", idx.Currency);
        Assert.Equal(0.32, idx.InflationRate, 3);
    }
}
