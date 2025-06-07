using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module16;

public class ThoughtEntity
{
    public string Name = string.Empty;
    public string CoreEmotion = string.Empty; // "Culpa", "Desejo", "Memoria", "Raiva"
    public string Region = string.Empty;
    public float InfluenceLevel; // 0-1
    public bool ManifestedPhysically;
}

public static class CollectiveEntitySystem
{
    public static List<ThoughtEntity> Entities { get; } = new();

    public static void TrySpawnEntity(string region)
    {
        float noise = MentalNoiseSystem.GetNoiseLevel(region);
        if (noise < 10f) return;

        string dominantEmotion = MentalNoiseSystem.ThoughtStream
            .FindLast(p => p.Region == region)?.ThoughtTag ?? "Medo";

        var entity = new ThoughtEntity
        {
            Name = $"Eco de {dominantEmotion}",
            CoreEmotion = dominantEmotion,
            Region = region,
            InfluenceLevel = Math.Min(noise / 100f, 1f),
            ManifestedPhysically = noise > 30f
        };

        Entities.Add(entity);
        Console.WriteLine($"\uD83D\uDC41\uFE0F ENTIDADE NASCEU: {entity.Name} em {region} | Emo\u00e7\u00e3o: {entity.CoreEmotion} | F\u00edsico? {entity.ManifestedPhysically}");
    }
}
