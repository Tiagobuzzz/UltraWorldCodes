using UltraWorldAI.Politics;
using Xunit;

public class LegitimacySystemTests
{
    [Fact]
    public void CalculatesAverageLegitimacy()
    {
        LegitimacySystem.Legitimacy.Clear();
        LegitimacySystem.Register("A", LegitimacySource.Sangue, 0.6f);
        LegitimacySystem.Register("A", LegitimacySource.Povo, 0.8f);
        var val = LegitimacySystem.GetOverall("A");
        Assert.True(val > 0.6f && val < 0.8f);
    }
}
