using System;
using System.Collections.Generic;

namespace UltraWorldAI.Conflict;

public class CivilizationalWar
{
    public string CultureA { get; set; } = string.Empty;
    public string CultureB { get; set; } = string.Empty;
    public string TechConflict { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Outcome { get; set; } = string.Empty;
    public bool IsResolved { get; set; }
}

public static class TechCivilizationConflict
{
    private static readonly Random Rng = new();
    public static List<CivilizationalWar> Wars { get; } = new();

    public static CivilizationalWar Declare(string a, string b, string tech, string reason)
    {
        var war = new CivilizationalWar
        {
            CultureA = a,
            CultureB = b,
            TechConflict = tech,
            Reason = reason,
            IsResolved = false
        };

        Wars.Add(war);
        return war;
    }

    public static void Resolve(CivilizationalWar war)
    {
        war.Outcome = Rng.NextDouble() > 0.5
            ? $"{war.CultureA} imp\u00f4s sua vis\u00e3o tecnol\u00f3gica."
            : $"{war.CultureB} venceu e suprimiu o estilo rival.";

        war.IsResolved = true;
    }

    public static string ListAll()
    {
        if (Wars.Count == 0) return "Nenhuma guerra civilizacional registrada.";
        return string.Join("\n\n", Wars.ConvertAll(w =>
            $"\u2694\uFE0F {w.CultureA} vs {w.CultureB}\nConflito: {w.TechConflict}\n" +
            $"Motivo: {w.Reason}\nResultado: {(w.IsResolved ? w.Outcome : "Em andamento")}"));
    }
}
