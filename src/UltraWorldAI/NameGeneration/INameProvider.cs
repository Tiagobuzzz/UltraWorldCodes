using System.Threading;
using System.Threading.Tasks;

namespace UltraWorldAI.Names;

public interface INameProvider
{
    Task<string> GetNameAsync(CancellationToken cancellationToken = default);
}
