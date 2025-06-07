using System;
using System.Collections.Generic;

namespace UltraWorldAI.Relationships;

public class LoveEffect
{
    public string Lover = string.Empty;
    public string Target = string.Empty;
    public float CreativityBoost;
    public float HealthImpact;
    public float MadnessGain;
    public string Reason = string.Empty; // "Paixão correspondida", "Amor não resolvido", "Obssessão doentia"
}

public static class LoveImpactSystem
{
    public static List<LoveEffect> Effects { get; } = new();

    public static void ApplyEffect(string lover, string target, float creativity, float health, float madness, string reason)
    {
        Effects.Add(new LoveEffect
        {
            Lover = lover,
            Target = target,
            CreativityBoost = creativity,
            HealthImpact = health,
            MadnessGain = madness,
            Reason = reason
        });

        Console.WriteLine($"\u2728 {lover} → {target} | Criatividade: +{creativity} | Saúde: {health:+0.##;-0.##} | Loucura: +{madness} | Motivo: {reason}");
    }

    public static void TickEffects()
    {
        foreach (var effect in Effects)
        {
            // Aqui você poderia integrar com subsistemas como mente, corpo e criação artística
            // Exemplo: aumentar criatividade real, regenerar ou prejudicar saúde, alterar sanidade
        }
    }
}
