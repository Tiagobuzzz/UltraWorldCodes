using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class ArtisticWork
{
    public string Author = string.Empty;
    public string Medium = string.Empty;
    public string Theme = string.Empty;
    public float Intensity;
}

public static class ArtisticExpressionSystem
{
    public static List<ArtisticWork> Artworks { get; } = new();

    public static void CreateWork(string author, string medium, string theme, float intensity)
    {
        Artworks.Add(new ArtisticWork
        {
            Author = author,
            Medium = medium,
            Theme = theme,
            Intensity = intensity
        });

        Console.WriteLine($"\uD83D\uDD8C\uFE0F {author} criou uma obra em {medium} com o tema: {theme} (Intensidade: {intensity})");
    }

    public static void PrintGallery()
    {
        foreach (var a in Artworks)
            Console.WriteLine($"\uD83C\uDFAD {a.Author} \u2192 {a.Medium} | Tema: {a.Theme} | Intensidade: {a.Intensity}");
    }
}
