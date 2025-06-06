using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class PhilosophicalDebate
{
    public string Location { get; set; } = string.Empty;
    public string ParticipantA { get; set; } = string.Empty;
    public string ParticipantB { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public string Outcome { get; set; } = string.Empty; // "Vitória A", "Vitória B", etc.
    public string ResultingChange { get; set; } = string.Empty;
}

public static class PhilosophicalDebateSystem
{
    public static List<PhilosophicalDebate> Debates { get; } = new();

    public static void HostDebate(
        string location,
        string participantA,
        string participantB,
        string topic,
        string outcome,
        string result)
    {
        var debate = new PhilosophicalDebate
        {
            Location = location,
            ParticipantA = participantA,
            ParticipantB = participantB,
            Topic = topic,
            Outcome = outcome,
            ResultingChange = result
        };

        Debates.Add(debate);
        Console.WriteLine($"\ud83d\udd0a Debate em {location}: {participantA} vs {participantB} sobre {topic} \u2192 {outcome} ({result})");
    }

    public static void PrintDebates()
    {
        foreach (var d in Debates)
        {
            Console.WriteLine($"\n\ud83d\udccd {d.Location} | Tema: {d.Topic}");
            Console.WriteLine($"\ud83e\udde0 {d.ParticipantA} vs {d.ParticipantB} | Resultado: {d.Outcome}");
            Console.WriteLine($"\ud83d\udcd8 Mudan\u00e7a: {d.ResultingChange}");
        }
    }
}
