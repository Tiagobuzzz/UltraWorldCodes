using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class TerritoryClaim
{
    public string RegionName { get; set; } = string.Empty;
    public string ClaimedBy { get; set; } = string.Empty;
    public DateTime ClaimDate { get; set; }
    public string ClaimType { get; set; } = string.Empty;
}

public static class TerritoryClaimSystem
{
    public static List<TerritoryClaim> Claims { get; } = new();

    public static void ClaimRegion(string region, string claimant, string type)
    {
        Claims.Add(new TerritoryClaim
        {
            RegionName = region,
            ClaimedBy = claimant,
            ClaimDate = DateTime.Now,
            ClaimType = type
        });
    }

    public static string DescribeAll()
    {
        if (Claims.Count == 0) return "Nenhuma região foi reivindicada.";
        return string.Join("\n\n", Claims.ConvertAll(c =>
            $"\uD83D\uDDFA {c.RegionName} foi reivindicada por {c.ClaimedBy} em {c.ClaimDate.ToShortDateString()}\nMotivo: {c.ClaimType}"));
    }
}
