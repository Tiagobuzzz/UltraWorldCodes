using System;
using System.Collections.Generic;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public class Rebellion
{
    public string Region { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public bool Succeeded { get; set; }
}

public static class RebellionTrigger
{
    public static List<Rebellion> Events { get; } = new();

    public static void Evaluate(Settlement s)
    {
        var rand = new Random();
        if (s.Population > 1000 && rand.NextDouble() < 0.1)
        {
            string cause = rand.NextDouble() < 0.5 ? "Desigualdade Social" : "Diferença Cultural Interna";
            bool success = rand.NextDouble() < 0.4;

            if (success)
            {
                s.Population /= 2;
                s.CultureSummary = "Facção Independente";
            }

            Events.Add(new Rebellion
            {
                Region = s.Region,
                Cause = cause,
                Succeeded = success
            });

            SettlementHistoryTracker.Register(s.Name, "Rebelião Interna", $"{cause} - {(success ? "Sucesso" : "Fracasso")}");
        }
    }
}
