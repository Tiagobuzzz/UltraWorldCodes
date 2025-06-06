using System.Collections.Generic;

namespace UltraWorldAI.World;

public static class BuildingUpgradeSystem
{
    private static readonly Dictionary<(string settlement, string building), int> _levels = new();

    public static void Upgrade(string settlement, string building)
    {
        var key = (settlement, building);
        _levels[key] = _levels.GetValueOrDefault(key) + 1;
        SettlementHistoryTracker.Register(settlement, "Upgrade", $"{building} nível {_levels[key]}");
    }

    public static int GetLevel(string settlement, string building) => _levels.GetValueOrDefault((settlement, building));
}
