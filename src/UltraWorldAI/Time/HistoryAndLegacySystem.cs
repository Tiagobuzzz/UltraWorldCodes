using System;
using System.Collections.Generic;

namespace UltraWorldAI.Time;

public class HistoryRecord
{
    public string Entity { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;
    public int Year { get; set; }
}

public class LegacyTag
{
    public string Entity { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
}

public static class HistoryAndLegacySystem
{
    public static List<HistoryRecord> History { get; } = new();
    public static List<LegacyTag> Legacies { get; } = new();

    public static void AddRecord(string entity, string description)
    {
        History.Add(new HistoryRecord
        {
            Entity = entity,
            Event = description,
            Year = EraTimelineSystem.GlobalYear
        });

        Console.WriteLine($"\ud83d\udcd6 Registro: {entity} \u2014 {description} (Ano {EraTimelineSystem.GlobalYear})");
    }

    public static void AssignLegacy(string entity, string tag)
    {
        Legacies.Add(new LegacyTag
        {
            Entity = entity,
            Tag = tag
        });

        Console.WriteLine($"\ud83c\udfdb\ufe0f Legado atribuído: {entity} \u2014 \"{tag}\"");
    }

    public static void PrintHistory()
    {
        foreach (var h in History)
            Console.WriteLine($"\n\ud83d\udd6e {h.Entity} | {h.Event} | Ano {h.Year}");
    }

    public static void PrintLegacies()
    {
        foreach (var l in Legacies)
            Console.WriteLine($"\n\ud83d\uddfe {l.Entity} possui o legado: \"{l.Tag}\"");
    }
}
