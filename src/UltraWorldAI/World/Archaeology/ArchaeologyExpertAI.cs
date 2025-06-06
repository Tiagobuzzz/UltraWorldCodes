using System.Collections.Generic;

namespace UltraWorldAI.World.Archaeology;

/// <summary>
/// Simple expert system specialized in archaeology and ancient history.
/// </summary>
public static class ArchaeologyExpertAI
{
    private static readonly Dictionary<string, string> _database = new();

    public static void AddKnowledge(string artifact, string description)
    {
        _database[artifact] = description;
    }

    public static string? Describe(string artifact)
    {
        return _database.TryGetValue(artifact, out var desc) ? desc : null;
    }
}
