using System;
using System.Collections.Generic;

namespace UltraWorldAI.Time;

public class Era
{
    public string Name { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public int StartYear { get; set; }
    public string Trigger { get; set; } = string.Empty;
}

public static class EraTimelineSystem
{
    public static List<Era> Eras { get; } = new();
    public static int GlobalYear { get; private set; }

    public static void AdvanceYear()
    {
        GlobalYear++;
        Console.WriteLine($"\ud83d\udcc6 Ano atual: {GlobalYear}");
    }

    public static void StartEra(string culture, string name, string trigger)
    {
        Eras.Add(new Era
        {
            Name = name,
            Culture = culture,
            StartYear = GlobalYear,
            Trigger = trigger
        });

        Console.WriteLine($"\ud83d\udd70\ufe0f Nova Era: {name} começou para {culture} | Gatilho: {trigger} | Ano: {GlobalYear}");
    }

    public static void PrintEras()
    {
        foreach (var e in Eras)
            Console.WriteLine($"\n\ud83d\udcdc {e.Culture} entrou na Era: {e.Name} (Início: {e.StartYear}) | Gatilho: {e.Trigger}");
    }

    public static void AdvanceEpoch(string name)
    {
        StartEra("global", name, "evento divino");
    }
}
