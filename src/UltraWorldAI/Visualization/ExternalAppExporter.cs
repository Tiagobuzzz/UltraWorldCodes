using UnityEngine;

namespace UltraWorldAI.Visualization;

/// <summary>
/// Exports summarized game data for consumption by external applications.
/// </summary>
public static class ExternalAppExporter
{
    public static string ExportSettlementData(World.Settlement settlement)
    {
        var info = new { settlement.Name, settlement.Region, settlement.Population };
        return JsonUtility.ToJson(info);
    }
}
