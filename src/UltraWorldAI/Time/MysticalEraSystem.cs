using System;
using System.Collections.Generic;

namespace UltraWorldAI.Time;

/// <summary>
/// Handles cultures experiencing mystical or fragmented eras.
/// </summary>
public class MysticalEra
{
    /// <summary>Culture associated with the era.</summary>
    public string Culture { get; set; } = string.Empty;

    /// <summary>Name of the era.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Type of era: cyclical, frozen, fragmented, eternal dream, etc.</summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>Trigger event that started the era.</summary>
    public string TriggerEvent { get; set; } = string.Empty;

    /// <summary>Indicates if the era runs in a temporal loop.</summary>
    public bool IsTemporalLoop { get; set; }
}

/// <summary>
/// Provides management functions for mystical eras.
/// </summary>
public static class MysticalEraSystem
{
    /// <summary>List of all mystical eras.</summary>
    public static List<MysticalEra> MysticalEras { get; } = new();

    /// <summary>Begins a mystical era for a given culture.</summary>
    public static void BeginMysticalEra(string culture, string name, string type, string triggerEvent, bool loop)
    {
        MysticalEras.Add(new MysticalEra
        {
            Culture = culture,
            Name = name,
            Type = type,
            TriggerEvent = triggerEvent,
            IsTemporalLoop = loop
        });

        Console.WriteLine($"\u23f3 Era M\u00edstica iniciada: {name} ({type}) para {culture} | Gatilho: {triggerEvent} | Loop Temporal? {loop}");
    }

    /// <summary>
    /// Prints all registered mystical eras to the console.
    /// </summary>
    public static void PrintMysticalEras()
    {
        foreach (var era in MysticalEras)
        {
            Console.WriteLine($"\n\ud83d\udd2e {era.Culture} vive a era: {era.Name} | Tipo: {era.Type} | Loop: {era.IsTemporalLoop} | Evento: {era.TriggerEvent}");
        }
    }
}

