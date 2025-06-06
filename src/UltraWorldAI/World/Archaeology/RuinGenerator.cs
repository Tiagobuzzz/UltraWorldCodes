using System;

namespace UltraWorldAI.World.Archaeology;

public class Ruin
{
    public string Region { get; set; } = string.Empty;
    public int Age { get; set; }
    public int LootQuality { get; set; }
}

public static class RuinGenerator
{
    private static readonly Random _rand = new();
    public static Ruin Generate(string region)
    {
        return new Ruin
        {
            Region = region,
            Age = _rand.Next(100, 1000),
            LootQuality = _rand.Next(1, 100)
        };
    }
}

public static class ArchaeologySystem
{
    public static string Explore(Ruin ruin, Person explorer)
    {
        var artifact = $"Artefato de {ruin.Region} ({ruin.Age} anos)";
        explorer.AddExperience($"Explorou ruínas em {ruin.Region}", 0.7f, 0.2f, new() { "arqueologia" });
        return artifact;
    }
}
