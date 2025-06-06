using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class RealitySpell
{
    public string Incantation { get; set; } = string.Empty;
    public string Effect { get; set; } = string.Empty;
    public double RequiredPrecision { get; set; }
}

public static class RealityManipulationSystem
{
    public static List<RealitySpell> Spells { get; } = new();

    public static void AddSpell(string incantation, string effect, double precision)
    {
        Spells.Add(new RealitySpell
        {
            Incantation = incantation,
            Effect = effect,
            RequiredPrecision = precision
        });
    }

    public static void CastSpell(string incantation, double spokenPrecision)
    {
        var spell = Spells.Find(s => s.Incantation == incantation);
        if (spell == null)
        {
            Console.WriteLine($"\u2753 Feiti\u00E7o '{incantation}' desconhecido.");
            return;
        }

        if (spokenPrecision >= spell.RequiredPrecision)
            Console.WriteLine($"\u2728 Efeito realizado: {spell.Effect}");
        else
            Console.WriteLine($"\u274C Palavras incorretas. A realidade n\u00E3o mudou.");
    }
}
