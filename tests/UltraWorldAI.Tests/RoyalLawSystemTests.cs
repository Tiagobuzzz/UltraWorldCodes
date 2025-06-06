using UltraWorldAI.Law;
using Xunit;

public class RoyalLawSystemTests
{
    [Fact]
    public void CreateLawAddsLaw()
    {
        RoyalLawSystem.Laws.Clear();
        RoyalLawSystem.CreateLaw("Kael", "Lei", "Desc");
        Assert.Single(RoyalLawSystem.Laws);
    }

    [Fact]
    public void RevokeLawDeactivates()
    {
        RoyalLawSystem.Laws.Clear();
        RoyalLawSystem.CreateLaw("Kael", "Lei", "Desc");
        RoyalLawSystem.RevokeLaw("Lei");
        Assert.False(RoyalLawSystem.Laws[0].IsActive);
    }
}
