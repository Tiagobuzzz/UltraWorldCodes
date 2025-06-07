using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class KnowledgeLineage
{
    public string Founder = string.Empty;
    public string SchoolName = string.Empty;
    public List<string> Descendants = new();
    public bool IsHeretical;
    public string CoreBelief = string.Empty;
    public int Hunts;
    public int Wars;
    public int Purifications;
}

public static class KnowledgeLineageSystem
{
    public static List<KnowledgeLineage> Schools { get; } = new();

    public static void RegisterLineage(
        string founder,
        string name,
        List<string> descendants,
        bool heresy,
        string belief)
    {
        Schools.Add(new KnowledgeLineage
        {
            Founder = founder,
            SchoolName = name,
            Descendants = descendants,
            IsHeretical = heresy,
            CoreBelief = belief
        });

        Console.WriteLine($"\ud83c\udfdb\ufe0f Escola '{name}' fundada por {founder} | Herética? {heresy} | Doutrina: {belief}");
    }

    public static void AddRepressionEvent(string school, string type)
    {
        var s = Schools.Find(sc => sc.SchoolName == school);
        if (s == null) return;

        switch (type)
        {
            case "caça":
                s.Hunts++;
                break;
            case "guerra":
                s.Wars++;
                break;
            case "purificação":
                s.Purifications++;
                break;
        }

        Console.WriteLine($"\u2694\ufe0f Evento '{type}' registrado contra a escola {school}");
    }
}
