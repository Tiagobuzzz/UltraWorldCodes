using System;
using System.Threading;
using System.Threading.Tasks;

namespace UltraWorldAI.Names;

public class RandomNameProvider : INameProvider
{
    private static readonly string[] Samples =
    {
        "Aelin","Borin","Ciri","Dorian","Elara","Fael" 
    };
    private readonly Random _rand = new();
    public Task<string> GetNameAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Samples[_rand.Next(Samples.Length)]);
    }
}
