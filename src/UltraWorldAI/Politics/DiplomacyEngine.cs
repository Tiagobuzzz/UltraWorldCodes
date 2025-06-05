using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public enum DiplomaticRelation
{
    Aliança,
    PactoDeNãoAgressão,
    Desconfiança,
    Inimizade,
    Guerra,
    Traição,
    CasamentoSimbolico
}

public class DiplomacyStatus
{
    public string KingdomA { get; set; } = string.Empty;
    public string KingdomB { get; set; } = string.Empty;
    public DiplomaticRelation Relation { get; set; }
    public string EstablishedBy { get; set; } = string.Empty;
    public string SymbolicReason { get; set; } = string.Empty;
    public DateTime EstablishedDate { get; set; }
}

public static class DiplomacyEngine
{
    public static List<DiplomacyStatus> Relations { get; } = new();

    public static void SetRelation(string a, string b, DiplomaticRelation relation, string by, string reason)
    {
        var rel = new DiplomacyStatus
        {
            KingdomA = a,
            KingdomB = b,
            Relation = relation,
            EstablishedBy = by,
            SymbolicReason = reason,
            EstablishedDate = DateTime.Now
        };

        Relations.Add(rel);
    }

    public static List<DiplomacyStatus> GetRelationsOf(string kingdom)
    {
        return Relations.FindAll(r => r.KingdomA == kingdom || r.KingdomB == kingdom);
    }

    public static string DescribeRelation(DiplomacyStatus rel)
    {
        return $"🤝 {rel.KingdomA} ↔ {rel.KingdomB} ({rel.Relation})\n" +
               $"Estabelecido por {rel.EstablishedBy} em {rel.EstablishedDate.ToShortDateString()}\n" +
               $"Motivo simbólico: {rel.SymbolicReason}";
    }

    public static string ListAll()
    {
        if (Relations.Count == 0) return "Nenhuma relação diplomática registrada.";
        return string.Join("\n\n", Relations.ConvertAll(DescribeRelation));
    }
}
