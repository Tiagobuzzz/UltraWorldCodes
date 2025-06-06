using System;
using System.Collections.Generic;

namespace UltraWorldAI.Time;

public class GlobalEvent
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int YearOccurred { get; set; }
    public string Impact { get; set; } = string.Empty;
}

public static class GlobalEventSystem
{
    public static List<GlobalEvent> Events { get; } = new();

    public static void TriggerEvent(string name, string type, string impact)
    {
        var year = EraTimelineSystem.GlobalYear;
        Events.Add(new GlobalEvent
        {
            Name = name,
            Type = type,
            Impact = impact,
            YearOccurred = year
        });

        Console.WriteLine($"\u2604\ufe0f Evento Global: {name} ({type}) ocorreu no ano {year} | Efeito: {impact}");
    }

    public static void PrintEvents()
    {
        foreach (var e in Events)
            Console.WriteLine($"\n\ud83c\udf0d {e.Name} | Tipo: {e.Type} | Ano: {e.YearOccurred} | Impacto: {e.Impact}");
    }
}
