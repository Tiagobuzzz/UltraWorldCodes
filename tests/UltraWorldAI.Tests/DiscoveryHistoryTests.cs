using UltraWorldAI.Discovery;
using Xunit;

public class DiscoveryHistoryTests
{
    [Fact]
    public void RegisterAddsEventToLog()
    {
        DiscoveryHistory.Log.Clear();
        DiscoveryHistory.Register("Fogo Vivo", "IA", "Tecnologia", "curiosidade", "teste");
        Assert.Single(DiscoveryHistory.Log);
        var output = DiscoveryHistory.DescribeAll();
        Assert.Contains("Fogo Vivo", output);
    }
}
