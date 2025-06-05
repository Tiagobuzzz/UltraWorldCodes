using System;

namespace UltraWorldAI.World;

public static class EnvironmentalFluxSystem
{
    public static void FluxBiome(WorldRegion region, string trigger)
    {
        string oldBiome = region.Biome;
        string newBiome = trigger switch
        {
            "guerra" => "Terra Queimada",
            "milagre" => "Solo Sagrado",
            "colapso" => "Ruínas Simbólicas",
            "sangue" => "Campo Ritual",
            _ => region.Biome
        };

        region.Biome = newBiome;
        LandMemorySystem.RecordEvent(region.Name, $"Mudança de Bioma: {oldBiome} → {newBiome}", $"Causado por {trigger}");
    }
}
