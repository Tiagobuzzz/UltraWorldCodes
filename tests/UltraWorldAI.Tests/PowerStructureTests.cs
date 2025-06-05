using UltraWorldAI.Politics;
using Xunit;

public class PowerStructureTests
{
    [Fact]
    public void CreateGovernmentGeneratesLawsAndSymbols()
    {
        var gov = GovernmentFactory.CreateGovernment(
            "Arcadia",
            GovernmentType.Republica,
            AuthorityBase.Voto,
            "Consul Aelius",
            "Vale Central");

        Assert.NotEmpty(gov.Laws);
        Assert.Contains(gov.Laws, l => l.Contains("povo"));
        Assert.Equal("Arcadia", gov.Name);
    }

    [Fact]
    public void DescribeReturnsFormattedString()
    {
        var gov = GovernmentFactory.CreateGovernment(
            "Sanctum",
            GovernmentType.Teocracia,
            AuthorityBase.Fe,
            "Sumo Patriarca",
            "Monte Alto");

        var desc = GovernmentFactory.Describe(gov);
        Assert.Contains("Sanctum", desc);
        Assert.Contains("Monte Alto", desc);
        Assert.Contains("Máscara", desc);
    }
}
