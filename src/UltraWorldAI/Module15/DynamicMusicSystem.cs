using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Module15;

public class Song
{
    public string Title = string.Empty;
    public string Composer = string.Empty;
    public string EmotionalState = string.Empty;
    public float HarmonyComplexity;
    public float LyricalIntensity;
}

public static class DynamicMusicSystem
{
    public static List<Song> Songs { get; } = new();

    public static void CreateSong(string title, string composer, string emotion, float harmony, float lyrics)
    {
        Songs.Add(new Song
        {
            Title = title,
            Composer = composer,
            EmotionalState = emotion,
            HarmonyComplexity = harmony,
            LyricalIntensity = lyrics
        });

        Console.WriteLine($"\uD83C\uDFBC M\u00fasica criada: {title} | Emo\u00e7\u00e3o: {emotion} | Harmonia: {harmony} | Letra: {lyrics}");
    }

    public static Song? GetMostComplex(string emotion)
    {
        return Songs.Where(s => s.EmotionalState == emotion)
            .OrderByDescending(s => s.HarmonyComplexity + s.LyricalIntensity)
            .FirstOrDefault();
    }
}
