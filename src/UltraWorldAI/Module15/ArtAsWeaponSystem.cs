using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class WeaponizedArt
{
    public string Title = string.Empty;
    public string Faction = string.Empty;
    public string Medium = string.Empty; // "Peça teatral", "Grafite", "Música", "Cartaz mágico"
    public string Target = string.Empty; // "Império do Norte", "Sacerdotes da Estase"
    public string Purpose = string.Empty; // "Profetizar queda", "Difamar", "Despertar levante"
}

public static class ArtAsWeaponSystem
{
    public static List<WeaponizedArt> Campaigns { get; } = new();

    public static void DeployArt(string title, string faction, string medium, string target, string purpose)
    {
        Campaigns.Add(new WeaponizedArt
        {
            Title = title,
            Faction = faction,
            Medium = medium,
            Target = target,
            Purpose = purpose
        });

        Console.WriteLine($"\u2694\uFE0F Arte usada como arma: {title} | Contra: {target} | Finalidade: {purpose}");
    }
}
