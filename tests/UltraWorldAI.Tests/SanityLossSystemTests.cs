using UltraWorldAI.Psychology;
using Xunit;

public class SanityLossSystemTests
{
    [Fact]
    public void LoseSanityStoresRecord()
    {
        SanityLossSystem.Records.Clear();
        SanityLossSystem.LoseSanity("Athena", "Segredo", 10);
        Assert.Single(SanityLossSystem.Records);
    }
}
