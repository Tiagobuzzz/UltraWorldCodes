using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class EnchantedArtwork
{
    public string Title = string.Empty;
    public string Creator = string.Empty;
    public string Medium = string.Empty;
    public string Effect = string.Empty;
    public bool RequiresRitual;
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
}
