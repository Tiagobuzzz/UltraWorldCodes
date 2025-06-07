using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class BodyCondition
{
    public string Name = string.Empty; // "Pulm\u00e3o Enfraquecido", "Bra\u00e7o Deformado"
    public string AffectedPart = string.Empty; // "Pulm\u00e3o", "Bra\u00e7o", "Olhos"
    public string Cause = string.Empty; // "Gen\u00e9tica", "Infec\u00e7\u00e3o", "Acidente"
    public float Severity; // 0.0 a 1.0
}

public class BodyProfile
{
    public string Name = string.Empty;
    public Dictionary<string, float> Organs = new();
    public List<BodyCondition> Conditions = new();
}

public static class BodyHealthSystem
{
    public static List<BodyProfile> Bodies { get; } = new();

    public static void RegisterBody(string name)
    {
        Bodies.Add(new BodyProfile
        {
            Name = name,
            Organs = new Dictionary<string, float>
            {
                {"Cora\u00e7\u00e3o", 1.0f},
                {"Pulm\u00e3o", 1.0f},
                {"F\u00edgado", 1.0f},
                {"Olhos", 1.0f}
            },
            Conditions = new List<BodyCondition>()
        });

        Console.WriteLine($"\uD83E\uDEC0 Corpo registrado: {name}");
    }

    public static void AddCondition(string name, BodyCondition condition)
    {
        var body = Bodies.Find(b => b.Name == name);
        if (body != null) body.Conditions.Add(condition);
    }

    public static void DamageOrgan(string name, string organ, float amount)
    {
        var body = Bodies.Find(b => b.Name == name);
        if (body != null && body.Organs.ContainsKey(organ))
            body.Organs[organ] = Math.Max(0, body.Organs[organ] - amount);
    }
}
