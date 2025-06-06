using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class GovernmentForm
{
    public string Kingdom { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Império", "República", "Teocracia", etc.
    public string SourceOfPower { get; set; } = string.Empty; // "Força", "Voto", "Profecia", etc.
    public string SuccessionLogic { get; set; } = string.Empty; // "Hereditária", "Eleições", etc.
}

public static class GovernmentFormSystem
{
    public static List<GovernmentForm> Forms { get; } = new();

    public static void SetGovernment(string kingdom, string type, string powerSource, string succession)
    {
        Forms.Add(new GovernmentForm
        {
            Kingdom = kingdom,
            Type = type,
            SourceOfPower = powerSource,
            SuccessionLogic = succession
        });

        Console.WriteLine($"⚖️ {kingdom} agora é uma {type} | Poder: {powerSource} | Sucessão: {succession}");
    }

    public static void PrintGovernments()
    {
        foreach (var f in Forms)
        {
            Console.WriteLine($"\n🏛️ {f.Kingdom}: {f.Type} | Origem do poder: {f.SourceOfPower} | Sucessão: {f.SuccessionLogic}");
        }
    }
}
