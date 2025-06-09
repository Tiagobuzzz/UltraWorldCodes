using System.Net.Http;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UltraWorldAI.Interface;
using Xunit;

public class NarrativeWebPlatformTests
{
    [Fact]
    public async Task ServerStoresNarratives()
    {
        using var server = new NarrativeWebPlatform(18080);
        server.Start();
        using var client = new HttpClient();
        var entry = new NarrativeEntry { Name = "Teste", Text = "Algo" };
        var content = new StringContent(JsonUtility.ToJson(entry), Encoding.UTF8, "application/json");
        await client.PostAsync("http://localhost:18080/narratives", content);
        var json = await client.GetStringAsync("http://localhost:18080/narratives");
        Assert.Contains("Algo", json);
    }
}
