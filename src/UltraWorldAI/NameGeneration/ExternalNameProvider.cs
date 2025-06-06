using System.Net.Http;
using System.Threading.Tasks;

namespace UltraWorldAI.Names;

public class ExternalNameProvider : INameProvider
{
    private readonly HttpClient _client = new();
    public async Task<string> GetNameAsync()
    {
        try
        {
            var resp = await _client.GetStringAsync("https://namey.muffinlabs.com/name.json?count=1");
            if (resp.StartsWith("["))
                resp = resp.Trim('[', ']', '"');
            return resp;
        }
        catch
        {
            return await new RandomNameProvider().GetNameAsync();
        }
    }
}
