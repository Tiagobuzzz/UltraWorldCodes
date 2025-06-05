using System;
using System.Collections.Generic;

namespace UltraWorldAI.World;

public class TectonicPlate
{
    public string Name { get; set; } = string.Empty;
    public List<string> Regions { get; set; } = new();
    public string Type { get; set; } = string.Empty; // Continental, Oceânica, Mista
    public double DriftDirection { get; set; }
    public double DriftSpeed { get; set; }
}

public static class TectonicPlateSystem
{
    public static List<TectonicPlate> Plates { get; } = new();

    public static void GeneratePlates(List<WorldRegion> regions)
    {
        var rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            var assigned = new List<string>();
            for (int j = 0; j < 5; j++)
            {
                var r = regions[rand.Next(regions.Count)];
                assigned.Add(r.Name);
            }

            Plates.Add(new TectonicPlate
            {
                Name = $"Placa-{i}",
                Regions = assigned,
                Type = i % 2 == 0 ? "Continental" : "Oceânica",
                DriftDirection = rand.Next(0, 360),
                DriftSpeed = rand.NextDouble() * 5 + 1
            });
        }
    }

    public static void SimulateYear()
    {
        foreach (var plate in Plates)
        {
            var rand = new Random();
            if (rand.NextDouble() < 0.1)
            {
                string affectedRegion = plate.Regions[rand.Next(plate.Regions.Count)];
                string eventType = rand.NextDouble() switch
                {
                    < 0.33 => "Terremoto",
                    < 0.66 => "Tsunami",
                    _ => "Erupção Vulcânica"
                };

                SettlementHistoryTracker.Register(affectedRegion, eventType, $"Atividade tectônica da {plate.Name}");
            }
        }
    }
}
