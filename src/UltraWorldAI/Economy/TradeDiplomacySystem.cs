using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class TradeTreaty
{
    public string Name { get; set; } = string.Empty;
    public List<string> Members { get; set; } = new();
    public string Type { get; set; } = string.Empty;
    public int TrustLevel { get; set; }
}

public static class TradeDiplomacySystem
{
    public static List<TradeTreaty> Treaties { get; } = new();

    public static void CreateTreaty(string name, string type, List<string> members)
    {
        Treaties.Add(new TradeTreaty
        {
            Name = name,
            Type = type,
            Members = new List<string>(members),
            TrustLevel = 100
        });

        Console.WriteLine($"\ud83d\udeea Novo tratado comercial criado: {name} ({type})");
    }

    public static void ModifyTrust(string treatyName, string actor, int delta)
    {
        var treaty = Treaties.FirstOrDefault(t => t.Name == treatyName);
        if (treaty == null || !treaty.Members.Contains(actor)) return;

        treaty.TrustLevel += delta;
        treaty.TrustLevel = Math.Clamp(treaty.TrustLevel, 0, 100);

        if (treaty.TrustLevel < 30)
            Console.WriteLine($"\u26a0\ufe0f Confian\u00e7a em {actor} no tratado {treatyName} est\u00e1 em risco: {treaty.TrustLevel}");
    }

    public static void Betrayal(string treatyName, string betrayer)
    {
        var treaty = Treaties.FirstOrDefault(t => t.Name == treatyName);
        if (treaty == null) return;

        treaty.Members.Remove(betrayer);
        treaty.TrustLevel -= 25;

        Console.WriteLine($"\ud83d\udc94 {betrayer} traiu o tratado {treatyName}! Confian\u00e7a geral caiu.");
    }

    public static void PrintTreaties()
    {
        foreach (var t in Treaties)
        {
            Console.WriteLine($"\ud83c\udf10 Tratado: {t.Name} | Tipo: {t.Type} | Confian\u00e7a: {t.TrustLevel} | Membros: {string.Join(", ", t.Members)}");
        }
    }
}
