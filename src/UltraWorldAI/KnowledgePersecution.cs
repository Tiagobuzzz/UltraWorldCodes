using System;
using System.Collections.Generic;
using UltraWorldAI;

namespace UltraWorldAI.Discovery;

public class ForbiddenKnowledge
{
    public string TechName { get; set; } = string.Empty;
    public string BannedBy { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool IsRemembered { get; set; }
}

public static class KnowledgePersecution
{
    public static List<ForbiddenKnowledge> Blacklist { get; } = new();

    public static void ForbidTech(string techName, string by, string reason)
    {
        Blacklist.Add(new ForbiddenKnowledge
        {
            TechName = techName,
            BannedBy = by,
            Reason = reason,
            Date = DateTime.Now,
            IsRemembered = new Random().NextDouble() > 0.5
        });
    }

    public static void ForbidTechWithMetacognition(string techName, string by, string reason, MetacognitionSystem meta)
    {
        ForbidTech(techName, by, reason);
        meta.RegisterForbiddenKnowledge(techName);
    }

    public static string DescribeAll()
    {
        if (Blacklist.Count == 0) return "Nenhuma tecnologia foi banida ainda.";
        return string.Join("\n\n", Blacklist.ConvertAll(k =>
            $"\u274C {k.TechName} proibida por {k.BannedBy} em {k.Date.ToShortDateString()}\n" +
            $"Motivo: {k.Reason} / Memória persistente: {(k.IsRemembered ? "Sim" : "Esquecida")}"));
    }

    public static bool IsForbidden(string techName)
    {
        return Blacklist.Exists(k => k.TechName == techName);
    }
}
