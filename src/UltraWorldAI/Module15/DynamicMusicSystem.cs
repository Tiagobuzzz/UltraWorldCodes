using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World;
using UltraWorldAI;

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

    public static void ApplyToCity(Song song, World.Settlement settlement)
    {
        settlement.Mood = song.EmotionalState;
        Console.WriteLine($"\uD83C\uDFBC {song.Title} afetou o humor de {settlement.Name} para {song.EmotionalState}");
    }

    public static void ApplyToGod(Song song, DivineBeing god)
    {
        god.Mood = song.EmotionalState;
        Console.WriteLine($"\uD83C\uDFBC {song.Title} tocado para {god.Name} agora está com humor {song.EmotionalState}");
    }
}
