using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module14;

public class MentalWorld
{
    public string Owner = string.Empty;
    public List<string> Locations = new(); // "Floresta da Culpa", "Templo da Esperança"
    public string GoverningSymbol = string.Empty; // "Flecha", "Espelho", "Coroa"
    public Dictionary<string, string> Entities = new(); // "Eco da mãe" => "Guia silenciosa"
}

public static class InternalWorldSystem
{
    public static List<MentalWorld> Worlds { get; } = new();

    public static void CreateWorld(string owner, List<string> locations, string symbol, Dictionary<string, string> entities)
    {
        Worlds.Add(new MentalWorld
        {
            Owner = owner,
            Locations = locations,
            GoverningSymbol = symbol,
            Entities = entities
        });

        Console.WriteLine($"🧠 Mundo interno de {owner} com símbolo regente: {symbol}");
    }

    public static void PrintWorlds()
    {
        foreach (var w in Worlds)
            Console.WriteLine($"\n🧩 {w.Owner} | Lugares: {string.Join(", ", w.Locations)} | Entidades: {string.Join(", ", w.Entities.Keys)}");
    }
}
