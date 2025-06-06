using System;
using System.Collections.Generic;
using UltraWorldAI.Economy;
using UltraWorldAI.Politics;

namespace UltraWorldAI.Education;

public class PhilosophicalDebate
{
    public string Location { get; set; } = string.Empty;
    public string ParticipantA { get; set; } = string.Empty;
    public string ParticipantB { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public string Outcome { get; set; } = string.Empty; // "Vitória A", "Vitória B", "Empate", "Revolta", "Conversão"
    public string ResultingChange { get; set; } = string.Empty;
}

public static class PhilosophicalDebateSystem
{
    public static List<PhilosophicalDebate> Debates { get; } = new();

    public static void HostDebate(
        string location,
        string a,
        string b,
        string topic,
        string outcome,
        string result,
        PowerStructure? government = null)
    {
        Debates.Add(new PhilosophicalDebate
        {
            Location = location,
            ParticipantA = a,
            ParticipantB = b,
            Topic = topic,
            Outcome = outcome,
            ResultingChange = result
        });

        Console.WriteLine($"🗣️ Debate em {location}: {a} vs {b} sobre {topic} → {outcome} ({result})");

        if (outcome.Contains("Revolta", StringComparison.OrdinalIgnoreCase) && government != null)
        {
            var msg = RevoltSystem.TriggerRevolt(government, a);
            Console.WriteLine(msg);
        }
        else if (outcome.Contains("Conversão", StringComparison.OrdinalIgnoreCase))
        {
            PhilosophySpreadSystem.PropagateToCulture(topic, location, 5);
        }
    }

    public static void PrintDebates()
    {
        foreach (var d in Debates)
        {
            Console.WriteLine($"\n📍 {d.Location} | Tema: {d.Topic}");
            Console.WriteLine($"🧠 {d.ParticipantA} vs {d.ParticipantB} | Resultado: {d.Outcome}");
            Console.WriteLine($"📘 Mudança: {d.ResultingChange}");
        }
    }
}
