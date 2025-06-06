using UltraWorldAI.Society;
using Xunit;

public class CommunityFeedbackSystemTests
{
    [Fact]
    public void GetAverageReturnsMeanScore()
    {
        var system = new CommunityFeedbackSystem();
        system.Submit("balance", 3);
        system.Submit("balance", 5);
        Assert.Equal(4.0, system.GetAverage("balance"), 1);
    }
}
