using System.Net.Http;
using System.Threading.Tasks;
using UltraWorldAI.Interface;
using UltraWorldAI.World;
using Xunit;

public class RealTimeStatsServerTests
{
    [Fact]
    public async Task ServerReturnsMapData()
    {
        MapFaithEconomyIntegration.Nodes.Clear();
        MapFaithEconomyIntegration.RegisterNode("Port", 50, false, false, "N/A");
        using var server = new RealTimeStatsServer(19999);
        server.Start();
        using var client = new HttpClient();
        var json = await client.GetStringAsync("http://localhost:19999/stats");
        Assert.Contains("Port", json);
    }
}
