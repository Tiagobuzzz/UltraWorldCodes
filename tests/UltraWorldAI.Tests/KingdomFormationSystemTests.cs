using UltraWorldAI.Politics;
using Xunit;

public class KingdomFormationSystemTests
{
    [Fact]
    public void FormsKingdomWhenLegitimacyHigh()
    {
        KingdomFormationSystem.ProtoLeaders.Clear();
        KingdomFormationSystem.FormedKingdoms.Clear();
        LegitimacySystem.Legitimacy.Clear();

        KingdomFormationSystem.AddLeader("Arthur", "Camelot", "Bret\u00f5es", 20, "Militar");
        LegitimacySystem.Register("Arthur", LegitimacySource.Povo, 0.9f);

        KingdomFormationSystem.EvaluateFormation();
        Assert.Contains("Reino de Arthur", KingdomFormationSystem.FormedKingdoms);
    }
}
