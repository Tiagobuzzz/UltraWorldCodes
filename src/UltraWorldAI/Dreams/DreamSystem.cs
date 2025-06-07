using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World.Ecology;
using UltraWorldAI.World;

namespace UltraWorldAI.Dreams;

public class Dream
{
    public string Dreamer = string.Empty;
    public string Region = string.Empty;
    public string Symbol = string.Empty;
    public string Emotion = string.Empty;
    public string DreamFragment = string.Empty;
    public DateTime Timestamp;
}

public static class DreamSystem
{
    public static List<Dream> AllDreams { get; } = new();

    public static Dream RecordDream(string ai, string region, string symbol, string emotion, string fragment)
    {
        var dream = new Dream
        {
            Dreamer = ai,
            Region = region,
            Symbol = symbol,
            Emotion = emotion,
            DreamFragment = fragment,
            Timestamp = DateTime.Now
        };

        AllDreams.Add(dream);
        Console.WriteLine($"\uD83C\uDF19 {ai} sonhou: {fragment} | Símbolo: {symbol} | Emoção: {emotion}");

        ApplyWorldEffects(dream);
        NightmareSpawnSystem.SpawnMonster(dream);

        return dream;
    }

    public static Dream RecordDream(string ai, string symbol, string emotion, string fragment) =>
        RecordDream(ai, "Desconhecido", symbol, emotion, fragment);

    private static void ApplyWorldEffects(Dream dream)
    {
        ClimateEventSystem.Generate(dream.Region);
        if (dream.Emotion.Equals("Medo", StringComparison.OrdinalIgnoreCase))
            DynamicTerrainModifier.ApplyEvent(dream.Region, "Terremoto");
    }

    public static List<Dream> GetRecentDreams(int hours = 24) =>
        AllDreams.Where(d => (DateTime.Now - d.Timestamp).TotalHours <= hours).ToList();
}
