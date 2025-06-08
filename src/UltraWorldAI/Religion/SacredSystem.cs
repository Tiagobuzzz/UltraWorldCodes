using System;
using System.Collections.Generic;
using UltraWorldAI.Territory;

namespace UltraWorldAI.Religion;

public class HolyArtifact
{
    public string Name = string.Empty;
    public string Effect = string.Empty;
    public string Origin = string.Empty;
    public bool IsHeresy;
}

public static class SacredSystem
{
    public static readonly List<HolyArtifact> Artifacts = new();

    public static void CreateArtifact(string name, string effect, string origin, bool isHeresy = false)
    {
        Artifacts.Add(new HolyArtifact
        {
            Name = name,
            Effect = effect,
            Origin = origin,
            IsHeresy = isHeresy
        });

        Console.WriteLine($"\uD83D\uDD11 Artefato {(isHeresy ? "her\u00e9tico" : "sagrado")} criado: {name} \u2192 {effect}");
    }

    public static void DesignatePilgrimageSite(string name, string location)
    {
        Console.WriteLine($"\uD83D\uDEB6 Local de peregrina\u00e7\u00e3o criado: {name} em {location}");
        SacredSpace.SanctifyRegion(location);
    }
}
