using UltraWorldAI.Thoughts;
using Xunit;

public class HistoricalIdentityTests
{
    [Fact]
    public void RegisterEventBuildsLegacy()
    {
        var history = new HistoricalIdentity();
        history.RegisterEvent("construiu um templo");
        history.RegisterEvent("fez um sacrifício");
        history.RegisterEvent("quebrou um tabu");
        history.RegisterEvent("construiu um monumento");
        Assert.NotEqual("Anônimo", history.MythicTitle);
        Assert.Equal(4, history.LifeEvents.Count);
        Assert.Contains("memórias", history.LegacyPhrase);
    }
}
