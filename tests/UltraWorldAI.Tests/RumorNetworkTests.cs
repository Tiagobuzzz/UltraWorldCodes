using UltraWorldAI.Communication;
using Xunit;

public class RumorNetworkTests
{
    [Fact]
    public void BroadcastAddsRumor()
    {
        RumorNetwork.Rumors.Clear();
        RumorNetwork.Broadcast("hello");
        Assert.Single(RumorNetwork.Rumors);
    }
}
