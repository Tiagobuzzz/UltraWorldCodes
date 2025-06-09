using System;
using UltraWorldAI.Discovery;

namespace UltraWorldAI.Science;

/// <summary>
/// Generates random scientific discoveries and logs them to DiscoveryHistory.
/// </summary>
public static class ScientificDiscoveryGenerator
{
    private static readonly string[] _fields = new[]
    {
        "Física",
        "Biologia",
        "Química",
        "Astronomia",
        "Matemática"
    };

    public static DiscoveryEvent Generate(string scientist)
    {
        var field = _fields[RandomSingleton.Shared.Next(_fields.Length)];
        var name = $"Desc-{field}-{RandomSingleton.Shared.Next(1000, 9999)}";
        DiscoveryHistory.Register(name, scientist, "Ciência", "entusiasmo", field);
        return DiscoveryHistory.Log[^1];
    }
}

