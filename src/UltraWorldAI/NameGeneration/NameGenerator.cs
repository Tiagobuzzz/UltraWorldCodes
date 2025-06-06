using System.Threading;
using System.Threading.Tasks;

namespace UltraWorldAI.Names;

public static class NameGenerator
{
    public static INameProvider Provider { get; set; } = new RandomNameProvider();

    public static Task<string> GenerateAsync(CancellationToken cancellationToken = default)
        => Provider.GetNameAsync(cancellationToken);
}
