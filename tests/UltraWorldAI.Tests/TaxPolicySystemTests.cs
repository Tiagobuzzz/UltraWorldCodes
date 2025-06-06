using UltraWorldAI.Economy;
using Xunit;

public class TaxPolicySystemTests
{
    [Fact]
    public void ApplyTaxCalculatesAmount()
    {
        TaxPolicySystem.SetTax("Villa", 0.2);
        var due = TaxPolicySystem.ApplyTax("Villa", 100);
        Assert.Equal(20, due, 1);
    }
}
