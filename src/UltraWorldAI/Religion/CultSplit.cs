using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Religion;

public class Cult
{
    public string Name { get; set; } = string.Empty;
    public string OriginDoctrine { get; set; } = string.Empty;
    public List<string> NewDogmas { get; set; } = new();
    public bool IsPersecuted { get; set; }
    public string FounderID { get; set; } = string.Empty;
    public string ReasonForSplit { get; set; } = string.Empty;
}

public static class CultSplit
{
    public static List<Cult> AllCults { get; } = new();

    public static Cult CreateCultFromDoctrine(Doctrine original, string founderID, string reason)
    {
        var cult = new Cult
        {
            Name = $"Voz de {founderID}",
            OriginDoctrine = original.Title,
            FounderID = founderID,
            ReasonForSplit = reason,
            NewDogmas = original.SacredRules
                .Where(r => !r.Contains("proibido"))
                .Select(r => $"Revisado: {r}")
                .ToList()
        };

        if (!original.IsMutable)
        {
            original.KnownHeresies.Add($"Cisma iniciado por {founderID}");
        }

        AllCults.Add(cult);
        return cult;
    }

    public static void PersecuteCult(Cult cult)
    {
        cult.IsPersecuted = true;
        cult.NewDogmas.Add("Sofremos por fé – e renascemos na dor.");
    }

    public static string DescribeCult(Cult cult)
    {
        return $"\uD83D\uDD94 Culto: {cult.Name}\nFundador: {cult.FounderID}\nOrigem: {cult.OriginDoctrine}\n" +
               $"Motivo do Cisma: {cult.ReasonForSplit}\nPerseguido: {cult.IsPersecuted}\n" +
               $"Dogmas: {string.Join(" / ", cult.NewDogmas)}";
    }

    public static string ListAllCults()
    {
        if (AllCults.Count == 0) return "Nenhum culto ou heresia registrada.";
        return string.Join("\n\n", AllCults.Select(DescribeCult));
    }
}

