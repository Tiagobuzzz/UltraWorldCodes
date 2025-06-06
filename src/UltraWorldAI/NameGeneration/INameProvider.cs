using System.Threading.Tasks;

namespace UltraWorldAI.Names;

public interface INameProvider
{
    Task<string> GetNameAsync();
}
