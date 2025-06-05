using System;
using System.Linq;

namespace UltraWorldAI.World;

public static class DynamicTerrainModifier
{
    public static void ApplyEvent(string region, string eventType)
    {
        switch (eventType)
        {
            case "Terremoto":
                SettlementHistoryTracker.Register(region, "Desastre", "Terreno rachado e instável.");
                ForceMigration(region, 0.4);
                break;
            case "Tsunami":
                SettlementHistoryTracker.Register(region, "Desastre", "Água invadiu estruturas e alterou margens.");
                ForceMigration(region, 0.6);
                break;
            case "Erupção Vulcânica":
                SettlementHistoryTracker.Register(region, "Mudança de Relevo", "Nova cadeia montanhosa formada.");
                ForceMigration(region, 0.8);
                break;
        }
    }

    private static void ForceMigration(string region, double chance)
    {
        var settlements = RaceSettlementDistributor.Settlements.Where(s => s.Region == region).ToList();
        var rand = new Random();
        foreach (var s in settlements)
        {
            if (rand.NextDouble() < chance)
            {
                var old = s.Region;
                s.Region = WorldSeedGenerator.GetNearbyRegion(old);
                SettlementHistoryTracker.Register(s.Name, "Migração Forçada", $"Deixou {old}, foi para {s.Region}");
            }
        }
    }
}
