using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class EconomicHeirloom
{
    public string OriginCulture { get; set; } = string.Empty;
    public string InheritorCulture { get; set; } = string.Empty;
    public string OriginalModel { get; set; } = string.Empty;
    public string NewModel { get; set; } = string.Empty;
    public string MutationType { get; set; } = string.Empty;
    public int Year { get; set; }
}

public static class HeirloomEconomySystem
{
    public static List<EconomicHeirloom> History { get; } = new();

    public static void InheritEconomy(string origin, string inheritor, string originalModel, string mutationType, int year)
    {
        string newModel = mutationType switch
        {
            "Preservado" => originalModel,
            "Transformado" => TransformModel(originalModel),
            "Corrompido" => "Dom\u00ednio/Controle",
            "H\u00edbrido" => $"{originalModel}+Moeda",
            _ => originalModel
        };

        History.Add(new EconomicHeirloom
        {
            OriginCulture = origin,
            InheritorCulture = inheritor,
            OriginalModel = originalModel,
            NewModel = newModel,
            MutationType = mutationType,
            Year = year
        });

        Console.WriteLine($"\uD83D\uDCDC {inheritor} herdou modelo econ\u00f4mico de {origin} ({mutationType}): {newModel}");
    }

    private static string TransformModel(string model)
    {
        return model switch
        {
            "Prest\u00edgio" => "Contrato de Honra",
            "Ritual" => "Rituais Comerciais",
            "Moeda" => "Cr\u00e9dito Avan\u00e7ado",
            "Servi\u00e7o" => "Servid\u00e3o Tempor\u00e1ria",
            "Barter" => "Troca Vinculada",
            _ => "Modelo Customizado"
        };
    }

    public static void PrintLineage(string culture)
    {
        var records = History
            .Where(h => h.InheritorCulture == culture)
            .Select(h => $"Ano {h.Year}: Herdou de {h.OriginCulture} ({h.OriginalModel} \u2192 {h.NewModel})")
            .ToList();

        Console.WriteLine($"\uD83D\uDCD6 Linha econ\u00f4mica de {culture}:\n{string.Join('\n', records)}");
    }
}
