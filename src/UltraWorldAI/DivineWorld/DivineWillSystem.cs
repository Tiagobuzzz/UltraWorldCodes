using System;
using System.Collections.Generic;

namespace UltraWorldAI.DivineWorld;

public enum DivinePersonality
{
    Compassionate,
    Chaotic,
    Vengeful,
    Silent,
    Creator
}

public class DivineAction
{
    public string Target { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Miracle", "Punishment", etc
    public string Description { get; set; } = string.Empty;
}

public static class DivineWillSystem
{
    public static DivinePersonality Personality { get; private set; } = DivinePersonality.Creator;
    public static List<DivineAction> Interventions { get; } = new();

    public static void Intervene(string target, string type, string description)
    {
        var action = new DivineAction
        {
            Target = target,
            Type = type,
            Description = description
        };

        Interventions.Add(action);
        Console.WriteLine($"\u26A1 Interven\u00e7\u00e3o divina: {type} em {target} → {description}");
    }

    public static void SetPersonality(DivinePersonality personality)
    {
        Personality = personality;
        Console.WriteLine($"\u2728 Personalidade divina definida: {personality}");
    }
}

