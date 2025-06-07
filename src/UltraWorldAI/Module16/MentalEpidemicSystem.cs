using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module16;

public enum EpidemicType { MassSuicide, InsaneArt, MentalPlague }

public class EpidemicEvent
{
    public string Region = string.Empty;
    public EpidemicType Type;
    public DateTime Timestamp;
}

public static class MentalEpidemicSystem
{
    public static List<EpidemicEvent> Events { get; } = new();

    public static void EvaluateRegion(string region)
    {
        float noise = MentalNoiseSystem.GetNoiseLevel(region);
        if (noise < 35f) return;

        var type = noise > 50f ? EpidemicType.MassSuicide : noise > 40f ? EpidemicType.InsaneArt : EpidemicType.MentalPlague;
        Events.Add(new EpidemicEvent { Region = region, Type = type, Timestamp = DateTime.Now });
        Console.WriteLine($"\uD83D\uDD25 Epidemia {type} detectada em {region} (Ru\u00eddo {noise:0.00})");
    }
}
