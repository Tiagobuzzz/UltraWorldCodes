using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module14;

public class PerceptionProfile
{
    public string Name = string.Empty;
    public string Mood = string.Empty; // "Ansioso", "Esperançoso", "Desconfiado"
    public string Belief = string.Empty; // "O mundo é sagrado", "Tudo é armadilha"
    public Dictionary<string, string> SensoryInterpretation = new(); // "Fogo" => "Purificação divina"
}

public static class SubjectivePerceptionSystem
{
    public static List<PerceptionProfile> Perceptions { get; } = new();

    public static void RegisterPerception(string name, string mood, string belief, Dictionary<string, string> interpretations)
    {
        Perceptions.Add(new PerceptionProfile
        {
            Name = name,
            Mood = mood,
            Belief = belief,
            SensoryInterpretation = interpretations
        });

        Console.WriteLine($"👁️ Percepção de {name} | Humor: {mood} | Crença: {belief}");
    }

    public static void PrintPerceptions()
    {
        foreach (var p in Perceptions)
            Console.WriteLine($"\n🧠 {p.Name} | Humor: {p.Mood} | Interpretações: {string.Join(", ", p.SensoryInterpretation)}");
    }
}
