using UltraWorldAI.Transport;
using Xunit;

public class TransportNetworkTests
{
    [Fact]
    public void AddRouteStoresRoute()
    {
        TransportNetwork.Routes.Clear();
        TransportNetwork.AddRoute("A", "B", 10);
        var route = TransportNetwork.GetRoute("A", "B");
        Assert.NotNull(route);
        Assert.Equal(10, route!.Distance);
    }
}
