using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class TectonicPlate
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Continental", "Oceânica"
    public int MovementX { get; set; }
    public int MovementY { get; set; }
}

public class TerrainCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public float Elevation { get; set; }
    public string Plate { get; set; } = string.Empty;
}

public static class TectonicWorldGenerator
{
    public static List<TectonicPlate> Plates { get; } = new();
    public static Dictionary<(int, int), TerrainCell> TerrainMap { get; } = new();

    public static void AddPlate(string name, string type, int moveX, int moveY)
    {
        Plates.Add(new TectonicPlate { Name = name, Type = type, MovementX = moveX, MovementY = moveY });
        Console.WriteLine($"\uD83C\uDF0D Placa criada: {name} ({type}) movimento: ({moveX}, {moveY})");
    }

    public static void GenerateTerrain(int width, int height)
    {
        var rand = new Random();
        foreach (var plate in Plates)
        {
            for (int i = 0; i < 200; i++)
            {
                int x = rand.Next(width);
                int y = rand.Next(height);
                float elevation = plate.Type == "Continental" ? rand.Next(30, 100) : rand.Next(-50, 10);
                TerrainMap[(x, y)] = new TerrainCell { X = x, Y = y, Elevation = elevation, Plate = plate.Name };
            }
        }
        Console.WriteLine($"\uD83D\uDDFA️ Terreno gerado com base em {Plates.Count} placas tectônicas.");
    }
}

