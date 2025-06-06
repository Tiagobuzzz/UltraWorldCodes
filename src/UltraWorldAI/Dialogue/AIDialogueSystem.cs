using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UltraWorldAI.Dialogue;

public static class AIDialogueSystem
{
    private static readonly HttpClient Client = new();

    public static async Task<string> GenerateDialogueAsync(string prompt)
    {
        var key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        if (!string.IsNullOrWhiteSpace(key))
        {
            try
            {
                Client.DefaultRequestHeaders.Clear();
                Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
                var content = new { model = "gpt-3.5-turbo", messages = new[] { new { role = "user", content = prompt } } };
                var response = await Client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", content);
                if (response.IsSuccessStatusCode)
                {
                    dynamic? data = await response.Content.ReadFromJsonAsync<dynamic>();
                    return data?.choices[0]?.message?.content ?? string.Empty;
                }
            }
            catch
            {
                // ignore connection issues
            }
        }

        return $"AI: resposta para '{prompt}'";
    }
}
