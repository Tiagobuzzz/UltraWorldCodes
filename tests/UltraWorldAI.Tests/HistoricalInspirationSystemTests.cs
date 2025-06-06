using UltraWorldAI;
using Xunit;

public class HistoricalInspirationSystemTests
{
    [Fact]
    public void ReturnsNonEmptyEvent()
    {
        var e = HistoricalInspirationSystem.GetRandomEvent();
        Assert.False(string.IsNullOrEmpty(e));
    }
}
