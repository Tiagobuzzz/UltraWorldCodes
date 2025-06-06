using System;
using System.Collections.Generic;

namespace UltraWorldAI.Territory;

public class Territory
{
    public string Name { get; set; } = string.Empty;
    public string OwnerKingdom { get; set; } = string.Empty;
    public string Governor { get; set; } = string.Empty;
    public bool IsDisputed { get; set; }
}

public static class PoliticalMapSystem
{
    public static List<Territory> Regions { get; } = new();

    public static void AssignRegion(string name, string owner, string governor, bool disputed)
    {
        Regions.Add(new Territory
        {
            Name = name,
            OwnerKingdom = owner,
            Governor = governor,
            IsDisputed = disputed
        });

        Console.WriteLine(disputed
            ? $"🗺️ Território em disputa: {name} (reivindicado por {owner}, governado por {governor})"
            : $"🗺️ Território {name} governado por {governor} sob domínio de {owner}");
    }

    public static void PrintRegions()
    {
        foreach (var r in Regions)
            Console.WriteLine($"\n🏞️ {r.Name} | Reino: {r.OwnerKingdom} | Governador: {r.Governor} | Disputa: {r.IsDisputed}");
    }
}
