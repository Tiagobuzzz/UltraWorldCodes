using System;
using System.Collections.Generic;

namespace UltraWorldAI.World.Creation;

public class LivingRuin
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool IsConscious { get; set; }
    public string Myth { get; set; } = string.Empty; // "Sepulcro que canta memórias", "Cidade que anda"
}

public static class LivingRuinsSystem
{
    public static List<LivingRuin> Ruins { get; } = new();

    public static void CreateRuin(string name, string location, bool conscious, string myth)
    {
        Ruins.Add(new LivingRuin
        {
            Name = name,
            Location = location,
            IsConscious = conscious,
            Myth = myth
        });

        Console.WriteLine($"\uD83D\uDDFF Ruína viva: {name} | Local: {location} | Consciente: {conscious} | Lenda: {myth}");
    }

    public static void PrintRuins()
    {
        foreach (var r in Ruins)
            Console.WriteLine($"\n\uD83C\uDFDA {r.Name} | Local: {r.Location} | Consciente? {r.IsConscious} | Lenda: {r.Myth}");
    }
}
