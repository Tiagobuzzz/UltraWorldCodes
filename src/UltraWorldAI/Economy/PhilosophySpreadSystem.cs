using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class SchoolFollower
{
    public string Culture { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public double InfluenceLevel { get; set; }
}

public static class PhilosophySpreadSystem
{
    public static List<SchoolFollower> InfluenceMap { get; } = new();

    public static void PropagateToCulture(string school, string culture, double influence)
    {
        var entry = InfluenceMap.FirstOrDefault(f => f.Culture == culture && f.School == school);
        if (entry != null)
        {
            entry.InfluenceLevel = Math.Min(100, entry.InfluenceLevel + influence);
        }
        else
        {
            entry = new SchoolFollower
            {
                Culture = culture,
                School = school,
                InfluenceLevel = Math.Clamp(influence, 0, 100)
            };
            InfluenceMap.Add(entry);
        }

        Console.WriteLine($"\ud83d\uddE3\ufe0f {school} propagado em {culture} \u2192 Influ\u00eancia atual: {entry.InfluenceLevel:0.0}");
    }

    public static void SpreadByMissionary(string school, IEnumerable<string> cultures, double intensity)
    {
        foreach (var c in cultures)
            PropagateToCulture(school, c, intensity);
    }

    public static void PrintInfluenceMap()
    {
        foreach (var i in InfluenceMap)
            Console.WriteLine($"\ud83c\udf0d {i.Culture} segue {i.School} com influ\u00eancia {i.InfluenceLevel:0.0}%");
    }
}
