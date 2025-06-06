using System.Collections.Generic;

namespace UltraWorldAI.Law;

/// <summary>
/// Handles basic registration of works for copyright and patents.
/// </summary>
public static class IPRightsSystem
{
    private static readonly Dictionary<string, string> _registry = new();

    public static void RegisterWork(string title, string owner)
    {
        _registry[title] = owner;
    }

    public static bool IsRegistered(string title) => _registry.ContainsKey(title);

    public static string? GetOwner(string title) =>
        _registry.TryGetValue(title, out var owner) ? owner : null;
}
