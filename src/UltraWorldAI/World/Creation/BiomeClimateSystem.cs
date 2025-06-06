using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class Biome
{
    public string Name { get; set; } = string.Empty;
    public float TempMin { get; set; }
    public float TempMax { get; set; }
    public float RainMin { get; set; }
    public float RainMax { get; set; }
}

public class ClimateZone
{
    public string Region { get; set; } = string.Empty;
    public float Temperature { get; set; }
    public float Rainfall { get; set; }
    public string CurrentBiome { get; set; } = string.Empty;
}

public static class BiomeClimateSystem
{
    public static List<Biome> Biomes { get; } = new();
    public static List<ClimateZone> Zones { get; } = new();

    public static void DefineBiome(string name, float tMin, float tMax, float rMin, float rMax)
    {
        Biomes.Add(new Biome { Name = name, TempMin = tMin, TempMax = tMax, RainMin = rMin, RainMax = rMax });
        Console.WriteLine($"\uD83C\uDF3E Bioma definido: {name}");
    }

    public static void GenerateClimateZone(string region, float temperature, float rainfall)
    {
        string biomeName = "Desconhecido";
        foreach (var b in Biomes)
        {
            if (temperature >= b.TempMin && temperature <= b.TempMax && rainfall >= b.RainMin && rainfall <= b.RainMax)
            {
                biomeName = b.Name;
                break;
            }
        }

        Zones.Add(new ClimateZone { Region = region, Temperature = temperature, Rainfall = rainfall, CurrentBiome = biomeName });
        Console.WriteLine($"\u26C5️ Região: {region} | Bioma: {biomeName} | Temp: {temperature}° | Chuva: {rainfall}mm");
    }
}

