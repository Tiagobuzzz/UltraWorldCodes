using System;
using System.Collections.Generic;

namespace UltraWorldAI.Time;

/// <summary>
/// Captures collective memories such as traumas or legends that influence cultures.
/// </summary>
public class CulturalMemory
{
    /// <summary>Culture this memory belongs to.</summary>
    public string Culture { get; set; } = string.Empty;

    /// <summary>Type of memory: Trauma, Lenda, Vitória, etc.</summary>
    public string MemoryType { get; set; } = string.Empty;

    /// <summary>Originating event of the memory.</summary>
    public string OriginEvent { get; set; } = string.Empty;

    /// <summary>Whether this memory influences future behavior.</summary>
    public bool InfluencesBehavior { get; set; }
}

/// <summary>
/// System that records and prints collective memories.
/// </summary>
public static class CollectiveMemorySystem
{
    /// <summary>List of all cultural memories.</summary>
    public static List<CulturalMemory> Memories { get; } = new();

    /// <summary>Registers a new collective memory.</summary>
    public static void RegisterMemory(string culture, string type, string origin, bool influences)
    {
        Memories.Add(new CulturalMemory
        {
            Culture = culture,
            MemoryType = type,
            OriginEvent = origin,
            InfluencesBehavior = influences
        });

        Console.WriteLine($"\ud83e\udd20 Memória coletiva registrada: {type} — {origin} em {culture} | Influencia comportamentos? {influences}");
    }

    /// <summary>
    /// Prints all registered collective memories.
    /// </summary>
    public static void PrintMemories()
    {
        foreach (var memory in Memories)
        {
            Console.WriteLine($"\n\ud83d\uddff {memory.Culture} | Memória: {memory.MemoryType} | Evento: {memory.OriginEvent} | Impacta decisões: {memory.InfluencesBehavior}");
        }
    }
}

