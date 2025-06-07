using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.Module16;

namespace UltraWorldAI.Magic;

public class PsychicChanneler
{
    public string Name = string.Empty;
    public string Region = string.Empty;
    public float StoredPower;
    public string Style = string.Empty; // "Alucinação", "Visão", "Grito Mental", "Maré Psíquica"
}

public static class PsychicMagicSystem
{
    public static List<PsychicChanneler> Channelers { get; } = new();

    public static void ChannelNoise(string ai, string region, string style)
    {
        float noise = MentalNoiseSystem.GetNoiseLevel(region);
        if (noise < 8f) return;

        var existing = Channelers.FirstOrDefault(c => c.Name == ai && c.Region == region);
        if (existing == null)
        {
            existing = new PsychicChanneler { Name = ai, Region = region, Style = style };
            Channelers.Add(existing);
        }

        existing.Style = style;
        existing.StoredPower += noise / 2f;
        Console.WriteLine($"\uD83E\uDDD9\u200D♂️ {ai} canalizou {noise:0.0} de ru\u00EDdo em {region} acumulando {existing.StoredPower:0.0} ({style})");
    }

    public static void CastMentalSpell(string ai, string spell)
    {
        var chan = Channelers.FirstOrDefault(x => x.Name == ai);
        if (chan == null || chan.StoredPower < 5f)
        {
            Console.WriteLine($"\u26A0\uFE0F {ai} tentou lan\u00E7ar {spell}, mas n\u00E3o tinha poder ps\u00EDquico suficiente.");
            return;
        }

        chan.StoredPower -= 5f;
        Console.WriteLine($"\u2728 {ai} lan\u00E7ou o feiti\u00E7o ps\u00EDquico '{spell}' usando {chan.Style}. Poder restante: {chan.StoredPower:0.0}");
    }
}
