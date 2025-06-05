using System.Collections.Generic;

namespace UltraWorldAI.World.Ecology;

public class EcologicalLink
{
    public string Predator { get; set; } = string.Empty;
    public string Prey { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Predação", "Simbiose" etc.
}

public static class EcosystemWeb
{
    public static List<EcologicalLink> Links { get; } = new();

    public static void AddLink(string predator, string prey, string type)
    {
        Links.Add(new EcologicalLink
        {
            Predator = predator,
            Prey = prey,
            Type = type
        });
    }

    public static string Summary()
    {
        return string.Join("\n", Links.ConvertAll(l => $"\uD83C\uDF0E {l.Predator} ↔ {l.Prey} ({l.Type})"));
    }
}
