using UltraWorldAI.Economy;
using Xunit;

public class MaritimeTradeSystemTests
{
    [Fact]
    public void VoyageGeneratesProfit()
    {
        MaritimeTradeSystem.Ports.Clear();
        MaritimeTradeSystem.Routes.Clear();
        MaritimeTradeSystem.RegisterPort("PortoA");
        MaritimeTradeSystem.RegisterPort("PortoB");
        var route = MaritimeTradeSystem.AddRoute("PortoA", "PortoB", 200);
        var value = MaritimeTradeSystem.SimulateVoyage(route, "Peixe", 10f);
        Assert.True(value > 0);
        Assert.Contains("Peixe", route.Goods);
    }
}
