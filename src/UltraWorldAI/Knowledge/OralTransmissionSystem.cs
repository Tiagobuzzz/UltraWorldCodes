using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class TeachingEvent
{
    public string Teacher = string.Empty;
    public string Student = string.Empty;
    public string KnowledgeTopic = string.Empty; // "Fermentação", "Arte da guerra"
    public float Effectiveness; // 0-1
    public string Context = string.Empty; // "Ritual", "Debate"
}

public static class OralTransmissionSystem
{
    public static List<TeachingEvent> History { get; } = new();

    public static void Teach(
        string teacher,
        string student,
        string topic,
        float effectiveness,
        string context)
    {
        History.Add(new TeachingEvent
        {
            Teacher = teacher,
            Student = student,
            KnowledgeTopic = topic,
            Effectiveness = effectiveness,
            Context = context
        });

        Console.WriteLine($"\uD83D\uDDE3\uFE0F {teacher} ensinou {topic} a {student} | Efetividade: {effectiveness} | Contexto: {context}");
    }
}
