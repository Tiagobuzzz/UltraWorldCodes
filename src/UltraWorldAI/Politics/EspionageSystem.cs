using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public static class EspionageSystem
{
    private static readonly Dictionary<string, int> _intel = new();

    public static void GatherIntel(string target, int amount)
    {
        if (!_intel.ContainsKey(target))
            _intel[target] = 0;
        _intel[target] += amount;
    }

    public static int GetIntel(string target) => _intel.TryGetValue(target, out var v) ? v : 0;
}
