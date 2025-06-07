using System;
using System.Collections.Generic;

namespace UltraWorldAI.Obscura;

public class ForbiddenLocation
{
    public string Name = string.Empty;
    public string Geometry = string.Empty; // "Loop Infinito", "Espaço Invertido"
    public string AccessCondition = string.Empty; // "Só entra quem esquece o próprio nome"
    public bool IsActive;
}

public static class ForbiddenLocationSystem
{
    public static List<ForbiddenLocation> Locations { get; } = new();

    public static void RegisterLocation(string name, string geometry, string condition)
    {
        var loc = new ForbiddenLocation
        {
            Name = name,
            Geometry = geometry,
            AccessCondition = condition,
            IsActive = true
        };

        Locations.Add(loc);
        Console.WriteLine($"🚫 Novo local proibido: {name} | Forma: {geometry} | Condição: {condition}");
    }

    public static bool TryAccess(string ai, string location)
    {
        var loc = Locations.Find(l => l.Name == location);
        if (loc == null || !loc.IsActive) return false;

        Console.WriteLine($"🔐 {ai} tentou acessar {location} ({loc.AccessCondition})");
        return true;
    }
}
