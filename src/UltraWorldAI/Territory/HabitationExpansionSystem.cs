using UltraWorldAI.World;

namespace UltraWorldAI.Territory;

public static class HabitationExpansionSystem
{
    /// <summary>
    /// Adds housing units to a settlement increasing capacity.
    /// </summary>
    public static void BuildHousing(Settlement settlement, int units)
    {
        settlement.HousingUnits += units;
        SettlementHistoryTracker.Register(settlement.Name, "Habitação", $"Construídas {units} casas");
    }

    /// <summary>
    /// Claims a new region for the given settlement.
    /// </summary>
    public static void ExpandTerritory(Settlement settlement, string region)
    {
        TerritoryClaimSystem.ClaimRegion(region, settlement.Name, "Expansão territorial");
        SettlementHistoryTracker.Register(settlement.Name, "Expansão", $"Expandiu para {region}");
    }
}
