using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public static class IndustrialEspionageSystem
{
    private static readonly Dictionary<string, List<string>> _stolen = new();

    public static void Steal(string thief, string target, string technology)
    {
        string key = $"{thief}->{target}";
        if (!_stolen.ContainsKey(key))
            _stolen[key] = new();
        _stolen[key].Add(technology);
        Logger.Log($"[Espionagem] {thief} roubou {technology} de {target}", LogLevel.Info);
    }

    public static IReadOnlyList<string> GetStolen(string thief, string target)
    {
        string key = $"{thief}->{target}";
        return _stolen.GetValueOrDefault(key) ?? new List<string>();
    }
}
