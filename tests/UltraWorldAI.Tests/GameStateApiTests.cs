using System.Net.Http;
using System.Threading.Tasks;
using UltraWorldAI.Interface;
using UltraWorldAI.World;
using Xunit;

[Collection("Sequential")]
public class GameStateApiTests
{
    [Fact]
    public async Task ApiReturnsMapData()
    {
        MapFaithEconomyIntegration.Nodes.Clear();
        MapFaithEconomyIntegration.RegisterNode("Outpost", 80, false, false, "N/A");
        using var api = new GameStateApi(19100);
        api.Start();
        using var client = new HttpClient();
        var json = await client.GetStringAsync("http://localhost:19100/map");
        Assert.Contains("Outpost", json);
    }
}
