using UltraWorldAI.Science;
using UltraWorldAI.Discovery;
using Xunit;

public class ScientificDiscoveryGeneratorTests
{
    [Fact]
    public void GenerateAddsDiscoveryToHistory()
    {
        DiscoveryHistory.Log.Clear();
        var evt = ScientificDiscoveryGenerator.Generate("Dr. X");
        Assert.Single(DiscoveryHistory.Log);
        Assert.Equal(evt, DiscoveryHistory.Log[0]);
    }
}

