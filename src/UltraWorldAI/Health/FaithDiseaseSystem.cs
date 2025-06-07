using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Health;

public class FaithDisease
{
    public string Name = string.Empty;
    public string RequiredBelief = string.Empty;
    public bool Cured;
}

public static class FaithDiseaseSystem
{
    private static readonly List<FaithDisease> _diseases = new();
    public static IReadOnlyList<FaithDisease> Diseases => _diseases;

    public static void AddDisease(string name, string belief)
    {
        _diseases.Add(new FaithDisease { Name = name, RequiredBelief = belief });
        Console.WriteLine($"\uD83E\uDDA5 Doen\u00e7a '{name}' associada \u00e0 cren\u00e7a '{belief}'.");
    }

    public static void ResolveByBelief(string culture, string belief)
    {
        foreach (var d in _diseases.Where(d => d.RequiredBelief == belief && !d.Cured))
        {
            d.Cured = true;
            Console.WriteLine($"\uD83C\uDFE5 Cultura '{culture}' curou '{d.Name}' pela f\u00e9 em '{belief}'.");
        }
    }

    public static void Reset() => _diseases.Clear();
}
