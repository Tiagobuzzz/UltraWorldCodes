using UltraWorldAI.World;
using Xunit;

public class ResourceManagementAITests
{
    [Fact]
    public void BalanceResourcesAdjustsWealth()
    {
        MapFaithEconomyIntegration.Nodes.Clear();
        ResourceConsumptionTracker.Register("Villa", 150);
        MapFaithEconomyIntegration.RegisterNode("Villa", 100, false, false, "N/A");

        ResourceManagementAI.BalanceResources();

        var wealth = MapFaithEconomyIntegration.Nodes[0].Wealth;
        Assert.NotEqual(100, wealth);
    }
}
