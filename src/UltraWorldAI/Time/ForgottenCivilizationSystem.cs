using System;
using System.Collections.Generic;

namespace UltraWorldAI.Time;

/// <summary>
/// Represents a lost or forgotten civilization ruin.
/// </summary>
public class Ruin
{
    /// <summary>Location of the ruin.</summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>Ancient name of the civilization.</summary>
    public string AncientName { get; set; } = string.Empty;

    /// <summary>Technology that was lost with the civilization.</summary>
    public string LostTechnology { get; set; } = string.Empty;

    /// <summary>Flag indicating if the ruin has been rediscovered.</summary>
    public bool HasBeenRediscovered { get; set; }
}

/// <summary>
/// Manages forgotten civilizations and their rediscovery.
/// </summary>
public static class ForgottenCivilizationSystem
{
    /// <summary>List of all ruins.</summary>
    public static List<Ruin> Ruins { get; } = new();

    /// <summary>Bury a civilization at the given location.</summary>
    public static void BuryCivilization(string location, string name, string lostTechnology)
    {
        Ruins.Add(new Ruin
        {
            Location = location,
            AncientName = name,
            LostTechnology = lostTechnology,
            HasBeenRediscovered = false
        });

        Console.WriteLine($"\ud83d\udecd\ufe0f Civilização esquecida: {name} sepultada em {location} | Tecnologia perdida: {lostTechnology}");
    }

    /// <summary>
    /// Marks a ruin as rediscovered if it exists and has not been discovered before.
    /// </summary>
    public static void Rediscover(string location)
    {
        var ruin = Ruins.Find(r => r.Location == location);
        if (ruin != null && !ruin.HasBeenRediscovered)
        {
            ruin.HasBeenRediscovered = true;
            Console.WriteLine($"\ud83d\udcdc Ruína redescoberta em {location} — Civilização: {ruin.AncientName}, Tecnologia: {ruin.LostTechnology}");
        }
    }

    /// <summary>
    /// Prints all known ruins and their status.
    /// </summary>
    public static void PrintRuins()
    {
        foreach (var ruin in Ruins)
        {
            Console.WriteLine($"\n\ud83e\uddf1 {ruin.Location} | Antiga: {ruin.AncientName} | Redescoberta? {ruin.HasBeenRediscovered} | Tecnologia: {ruin.LostTechnology}");
        }
    }
}

