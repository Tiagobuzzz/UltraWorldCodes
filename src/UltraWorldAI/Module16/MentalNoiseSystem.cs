using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Module16;

public class ThoughtPulse
{
    public string SourceAI = string.Empty;
    public string ThoughtTag = string.Empty; // "Medo", "Culpa", "Esperanca", "Solidao", "Revolta"
    public float EmotionalWeight;
    public string Region = string.Empty;
    public DateTime Timestamp;
}

public static class MentalNoiseSystem
{
    public static List<ThoughtPulse> ThoughtStream { get; } = new();

    public static void EmitThought(string ai, string tag, float weight, string region)
    {
        ThoughtStream.Add(new ThoughtPulse
        {
            SourceAI = ai,
            ThoughtTag = tag,
            EmotionalWeight = weight,
            Region = region,
            Timestamp = DateTime.Now
        });

        Console.WriteLine($"\uD83C\uDF00 {ai} gerou pensamento '{tag}' com peso {weight:0.00} em {region}");
    }

    public static float GetNoiseLevel(string region)
    {
        var recent = ThoughtStream
            .Where(p => p.Region == region && (DateTime.Now - p.Timestamp).TotalHours <= 12)
            .Sum(p => p.EmotionalWeight);

        return recent;
    }
}
