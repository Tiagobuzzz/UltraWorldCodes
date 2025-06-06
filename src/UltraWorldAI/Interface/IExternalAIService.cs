using System.Threading.Tasks;

namespace UltraWorldAI.Interface;

public interface IExternalAIService
{
    Task<string> QueryAsync(string endpoint, string prompt);
}
