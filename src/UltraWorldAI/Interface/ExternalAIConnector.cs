using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UltraWorldAI.Interface;

/// <summary>
/// Simple HTTP connector for external AI services.
/// </summary>
public class ExternalAIConnector : IExternalAIService
{
    private readonly HttpClient _client = new();

    /// <summary>
    /// Sends a text prompt to the configured endpoint and returns the raw response.
    /// </summary>
    public async Task<string> QueryAsync(string endpoint, string prompt, CancellationToken cancellationToken = default)
    {
        StringContent content = new(JsonSerializer.Serialize(new { prompt }), Encoding.UTF8, "application/json");
        try
        {
            using HttpResponseMessage response = await _client.PostAsync(endpoint, content, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
        catch (HttpRequestException ex)
        {
            Logger.LogError("External AI request failed", ex);
            return string.Empty;
        }
    }
}
