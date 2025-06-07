using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module16;

public class NoiseSpell
{
    public string Caster = string.Empty;
    public string Region = string.Empty;
    public float Power;
    public string Effect = string.Empty;
    public DateTime Timestamp;
}

public static class NoiseSorcerySystem
{
    public static List<NoiseSpell> Spells { get; } = new();

    public static void ChannelNoise(string caster, string region)
    {
        float noise = MentalNoiseSystem.GetNoiseLevel(region);
        if (noise <= 0f) return;

        var spell = new NoiseSpell
        {
            Caster = caster,
            Region = region,
            Power = noise,
            Effect = noise > 20f ? "Explosao de Caos" : "Ondas Psiquicas",
            Timestamp = DateTime.Now
        };

        Spells.Add(spell);
        Console.WriteLine($"\uD83E\uDEA5 {caster} canaliza ru\u00eddo {noise:0.00} em {region} gerando {spell.Effect}");
    }
}
