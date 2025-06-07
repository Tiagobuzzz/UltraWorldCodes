using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Module15;

public class Song
{
    public string Composer = string.Empty;
    public string Title = string.Empty;
    public string Mood = string.Empty;
    public float Intensity;
}

public static class DynamicMusicSystem
{
    public static List<Song> Songs { get; } = new();

    public static void ComposeSong(string composer, string title, string mood, float intensity)
    {
        Songs.Add(new Song
        {
            Composer = composer,
            Title = title,
            Mood = mood,
            Intensity = intensity
        });

        Console.WriteLine($"\uD83C\uDFB5 {composer} comp\u00F4s '{title}' em tom {mood} (Intensidade: {intensity})");
    }

    public static Song? GetMostIntense(string mood)
    {
        return Songs.Where(s => s.Mood == mood).OrderByDescending(s => s.Intensity).FirstOrDefault();
    }
}
