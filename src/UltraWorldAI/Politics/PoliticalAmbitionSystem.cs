using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class AmbitionProfile
{
    public string Name { get; set; } = string.Empty;
    public string CurrentRank { get; set; } = string.Empty;
    public string DesiredTitle { get; set; } = string.Empty;
    public bool IsScheming { get; set; }
}

public static class PoliticalAmbitionSystem
{
    public static List<AmbitionProfile> Profiles { get; } = new();

    public static void RegisterAmbition(string name, string rank, string goal)
    {
        Profiles.Add(new AmbitionProfile
        {
            Name = name,
            CurrentRank = rank,
            DesiredTitle = goal,
            IsScheming = true
        });

        Console.WriteLine($"\U0001F9E0 {name} está tramando para deixar de ser {rank} e se tornar {goal}.");
    }

    public static void PrintAmbitions()
    {
        foreach (var p in Profiles)
            Console.WriteLine($"\n\uD83C\uDFAF {p.Name} | De: {p.CurrentRank} ➜ Para: {p.DesiredTitle} | Esquema ativo? {p.IsScheming}");
    }
}
