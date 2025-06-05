using System;
using System.Collections.Generic;
using UltraWorldAI.World;
using UltraWorldAI.Civilization;

namespace UltraWorldAI.Politics.War;

public class Army
{
    public string Settlement { get; set; } = string.Empty;
    public string CultureStyle { get; set; } = string.Empty;
    public int Size { get; set; }
    public string Strategy { get; set; } = string.Empty;
}

public static class ArmyMobilizer
{
    public static List<Army> Armies { get; } = new();

    public static void Mobilize(War war)
    {
        var attacker = RaceSettlementDistributor.Settlements.Find(s => s.Name == war.Attacker);
        if (attacker == null) return;

        string style = attacker.CultureSummary;
        int size = attacker.Population / 10;

        Armies.Add(new Army
        {
            Settlement = attacker.Name,
            CultureStyle = style,
            Size = size,
            Strategy = DetermineStrategy(style)
        });
    }

    private static string DetermineStrategy(string culture)
    {
        return culture switch
        {
            "Conselhos Eternos" => "Retaliação Tática",
            "Impérios Brutalistas" => "Ataque Total",
            "Clãs" => "Emboscadas e Defesa",
            "Coletivos Temporários" => "Guerra Relâmpago",
            "Confederação Cultural" => "Cerco Prolongado",
            _ => "Skirmish Irregular"
        };
    }
}
