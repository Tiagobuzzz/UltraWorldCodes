using UltraWorldAI.Discovery;
using UltraWorldAI.Science;
using Xunit;

public class ParanormalEventGeneratorTests
{
    [Fact]
    public void GenerateLogsParanormalEvent()
    {
        DiscoveryHistory.Log.Clear();
        var evt = ParanormalEventGenerator.Generate("Psi");
        Assert.Equal("Paranormal", evt.Type);
        Assert.Single(DiscoveryHistory.Log);
    }
}
