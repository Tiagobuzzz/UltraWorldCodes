using System;
using UltraWorldAI.Discovery;

namespace UltraWorldAI.Science;

/// <summary>
/// Generates random scientific discoveries and logs them to DiscoveryHistory.
/// </summary>
public static class ScientificDiscoveryGenerator
{
    private static readonly string[] _fields =
        ["Física", "Biologia", "Química", "Astronomia", "Matemática"];

    public static DiscoveryEvent Generate(string scientist)
    {
        var field = _fields[Random.Shared.Next(_fields.Length)];
        var name = $"Desc-{field}-{Random.Shared.Next(1000, 9999)}";
        DiscoveryHistory.Register(name, scientist, "Ciência", "entusiasmo", field);
        return DiscoveryHistory.Log[^1];
    }
}

