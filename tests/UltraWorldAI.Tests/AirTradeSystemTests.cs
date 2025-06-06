using UltraWorldAI.Economy;
using Xunit;

public class AirTradeSystemTests
{
    [Fact]
    public void FlightGeneratesValue()
    {
        AirTradeSystem.Hubs.Clear();
        AirTradeSystem.Routes.Clear();
        AirTradeSystem.RegisterHub("A");
        AirTradeSystem.RegisterHub("B");
        var route = AirTradeSystem.AddRoute("A", "B", 100);
        var value = AirTradeSystem.SimulateFlight(route, "ouro", 5f);
        Assert.True(value > 0f);
        Assert.Contains("ouro", route.Goods);
    }
}

