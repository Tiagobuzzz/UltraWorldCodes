using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class VassalRelation
{
    public string Lord { get; set; } = string.Empty;
    public string Vassal { get; set; } = string.Empty;
    public string Feudo { get; set; } = string.Empty;
    public string Oath { get; set; } = string.Empty; // "Lealdade", "Guerra", "Fé", "Sangue"
    public bool IsLoyal { get; set; }
}

public static class VassalageSystem
{
    public static List<VassalRelation> Relations { get; } = new();

    public static void DeclareVassal(string lord, string vassal, string feudo, string oath)
    {
        Relations.Add(new VassalRelation
        {
            Lord = lord,
            Vassal = vassal,
            Feudo = feudo,
            Oath = oath,
            IsLoyal = true
        });

        Console.WriteLine($"🛡️ {vassal} jurou {oath} ao senhor {lord} e recebeu o feudo de {feudo}.");
    }

    public static void BreakOath(string vassal)
    {
        var relation = Relations.Find(r => r.Vassal == vassal);
        if (relation != null)
        {
            relation.IsLoyal = false;
            Console.WriteLine($"⚠️ {vassal} quebrou o juramento com {relation.Lord}!");
        }
    }

    public static void PrintRelations()
    {
        foreach (var r in Relations)
            Console.WriteLine($"\n⚔️ Vassalo: {r.Vassal} | Senhor: {r.Lord} | Feudo: {r.Feudo} | Juramento: {r.Oath} | Leal? {r.IsLoyal}");
    }
}
