using System.Collections.Generic;

namespace UltraWorldAI.World;

public static class CityArchitectureSystem
{
    private static readonly Dictionary<string, string> Styles = new();

    public static void SetStyle(Settlement settlement, string style)
    {
        settlement.ArchitectureStyle = style;
        Styles[settlement.Name] = style;
    }

    public static string GetStyle(Settlement settlement)
    {
        return Styles.TryGetValue(settlement.Name, out var s) ? s : settlement.ArchitectureStyle;
    }
}
