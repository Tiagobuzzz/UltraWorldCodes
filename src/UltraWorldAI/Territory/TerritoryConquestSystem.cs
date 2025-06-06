using System.Collections.Generic;

namespace UltraWorldAI.Territory;

public class TerritoryBorder
{
    public string Owner { get; set; } = string.Empty;
    public List<(int x, int y)> Tiles { get; set; } = new();
}

public static class TerritoryConquestSystem
{
    public static List<TerritoryBorder> Borders { get; } = new();

    public static void Claim(string owner, List<(int x, int y)> tiles)
    {
        Borders.Add(new TerritoryBorder { Owner = owner, Tiles = new List<(int, int)>(tiles) });
    }

    public static void Conquer(string attacker, string defender)
    {
        var target = Borders.Find(b => b.Owner == defender);
        if (target == null) return;
        target.Owner = attacker;
    }
}
