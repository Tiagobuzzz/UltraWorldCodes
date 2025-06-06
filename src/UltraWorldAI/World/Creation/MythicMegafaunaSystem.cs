using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class Megafauna
{
    public string Name { get; set; } = string.Empty;
    public string Biome { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty; // "Enorme", "Titanesca", "Continental"
    public string MagicalAffinity { get; set; } = string.Empty; // "Fogo", "Tempo", "Sombras"
    public bool IsWorshipped { get; set; }
}

public static class MythicMegafaunaSystem
{
    public static List<Megafauna> Creatures { get; } = new();

    public static void SpawnMegafauna(string name, string biome, string size, string affinity, bool worship)
    {
        Creatures.Add(new Megafauna
        {
            Name = name,
            Biome = biome,
            Size = size,
            MagicalAffinity = affinity,
            IsWorshipped = worship
        });

        Console.WriteLine($"\uD83D\uDC18 Megafauna criada: {name} | Bioma: {biome} | Tamanho: {size} | Magia: {affinity} | Cultuada? {worship}");
    }

    public static void PrintMegafauna()
    {
        foreach (var m in Creatures)
            Console.WriteLine($"\n\uD83E\uDD96 {m.Name} | Bioma: {m.Biome} | Tamanho: {m.Size} | Magia: {m.MagicalAffinity} | Cultuada: {m.IsWorshipped}");
    }
}
