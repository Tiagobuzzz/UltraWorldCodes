using System;
using System.Collections.Generic;
using UltraWorldAI.World;

namespace UltraWorldAI.Module15;

public class CollectivePerformance
{
    public string Title = string.Empty;
    public List<string> Groups = new();
    public string Region = string.Empty;
    public string Effect = string.Empty;
}

public static class RegionalPerformanceSystem
{
    public static List<CollectivePerformance> Performances { get; } = new();

    public static void Organize(string title, List<string> groups, string region, string effect)
    {
        Performances.Add(new CollectivePerformance
        {
            Title = title,
            Groups = groups,
            Region = region,
            Effect = effect
        });

        WorldImpactSystem.ApplyImpact(title, region, "cultura");
        Console.WriteLine($"\uD83C\uDFAD Performance coletiva '{title}' em {region} causa efeito: {effect}");
    }
}
