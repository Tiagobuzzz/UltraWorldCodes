using System;
using System.Collections.Generic;

namespace UltraWorldAI.DivineWorld;

public static class WorldShapingSystem
{
    public static List<string> CreatedElements { get; } = new();

    public static void CreateGeography(string elementType, string name)
    {
        CreatedElements.Add($"{elementType}: {name}");
        Console.WriteLine($"\uD83D\uDDFA\uFE0F Geografia criada: {elementType} – {name}");
    }

    public static void CreateRace(string name, string traits, string language)
    {
        Console.WriteLine($"\uD83E\uDDEC Ra\u00e7a criada: {name} | Tra\u00e7os: {traits} | L\u00edngua: {language}");
    }

    public static void DefineLaw(string lawType, string description)
    {
        Console.WriteLine($"\uD83D\uDCDC Lei divina estabelecida: {lawType} → {description}");
    }
}

