using System;
using System.Collections.Generic;

namespace UltraWorldAI.Relationships;

public class UnconsciousBond
{
    public string Subject = string.Empty;
    public string Target = string.Empty;
    public string Type = string.Empty; // "Desejo inconsciente", "Amor platônico", "Rivalidade afetiva"
    public float EmotionalWeight;
    public bool Aware;
}

public static class UnconsciousDesireSystem
{
    public static List<UnconsciousBond> HiddenBonds { get; } = new();

    public static void CreateBond(string subject, string target, string type, float weight, bool aware)
    {
        HiddenBonds.Add(new UnconsciousBond
        {
            Subject = subject,
            Target = target,
            Type = type,
            EmotionalWeight = weight,
            Aware = aware
        });

        Console.WriteLine($"\uD83C\uDF00 {subject} → {target} | Tipo: {type} | Intensidade: {weight} | Consciente? {aware}");
    }
}
