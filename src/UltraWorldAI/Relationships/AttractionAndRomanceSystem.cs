using System;
using System.Collections.Generic;

namespace UltraWorldAI.Relationships;

public class AttractionProfile
{
    public string Name = string.Empty;
    public Dictionary<string, float> TraitPreferences = new();
    public List<string> RecentInteractions = new();
    public string RomanticState = string.Empty;
}

public static class AttractionAndRomanceSystem
{
    public static List<AttractionProfile> Profiles { get; } = new();

    public static void RegisterAttraction(string name, Dictionary<string, float> preferences, List<string> interactions, string state)
    {
        Profiles.Add(new AttractionProfile
        {
            Name = name,
            TraitPreferences = preferences,
            RecentInteractions = interactions,
            RomanticState = state
        });

        Console.WriteLine($"\uD83D\uDC98 {name} feels: {state} | Based on: {string.Join(", ", preferences.Keys)}");
    }
}
