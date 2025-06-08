using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public class SacredArtifact
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool IsTechHeresy { get; set; }
}

public static class PilgrimageSystem
{
    public static List<SacredArtifact> Artifacts { get; } = new();
    public static List<string> PilgrimageSites { get; } = new();

    public static SacredArtifact AddArtifact(string name, string location, bool techHeresy = false)
    {
        var artifact = new SacredArtifact { Name = name, Location = location, IsTechHeresy = techHeresy };
        Artifacts.Add(artifact);
        return artifact;
    }

    public static void RegisterSite(string name)
    {
        if (!PilgrimageSites.Contains(name)) PilgrimageSites.Add(name);
    }
}

