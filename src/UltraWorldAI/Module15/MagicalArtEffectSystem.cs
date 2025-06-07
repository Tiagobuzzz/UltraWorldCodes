using System;
using System.Collections.Generic;
using UltraWorldAI.World;

namespace UltraWorldAI.Module15;

public class EnchantedArtwork
{
    public string Title = string.Empty;
    public string Creator = string.Empty;
    public string Medium = string.Empty;
    public string Effect = string.Empty;
    public bool RequiresRitual;
    public string? PropheticVision;
}

public static class MagicalArtEffectSystem
{
    public static List<EnchantedArtwork> Artworks { get; } = new();

    public static void CreateMagicalArt(string title, string creator, string medium, string effect, bool ritual)
    {
        Artworks.Add(new EnchantedArtwork
        {
            Title = title,
            Creator = creator,
            Medium = medium,
            Effect = effect,
            RequiresRitual = ritual
        });

        Console.WriteLine($"\uD83E\uDD84 Arte m\u00e1gica: {title} | Efeito: {effect} | Ritual? {ritual}");
    }

    public static void ApplyEffect(string title, string region)
    {
        var art = Artworks.Find(a => a.Title == title);
        if (art != null)
        {
            WorldImpactSystem.ApplyImpact(title, region, "cultura");
            Console.WriteLine($"\uD83E\uDD84 {title} afetou {region} com {art.Effect}");
        }
    }

    public static void EmbedProphecy(string title, string vision)
    {
        var art = Artworks.Find(a => a.Title == title);
        if (art != null)
        {
            art.PropheticVision = vision;
            Console.WriteLine($"\uD83D\uDD2E Profecia adicionada a {title}: {vision}");
        }
    }

    public static string? RevealProphecy(string title)
    {
        var art = Artworks.Find(a => a.Title == title);
        return art?.PropheticVision;
    }
}
