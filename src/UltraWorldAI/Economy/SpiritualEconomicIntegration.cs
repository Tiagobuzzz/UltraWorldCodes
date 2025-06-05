using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class DivineTax
{
    public string Deity { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public double TaxRate { get; set; }
    public string TempleSettlement { get; set; } = string.Empty;
}

public static class SpiritualEconomicIntegration
{
    public static List<DivineTax> DivineTaxes { get; } = new();

    public static void RegisterDivineTax(string deity, string culture, double rate, string temple)
    {
        DivineTaxes.Add(new DivineTax
        {
            Deity = deity,
            Culture = culture,
            TaxRate = rate,
            TempleSettlement = temple
        });
    }

    public static void ProcessTithes(string culture, double localIncome)
    {
        foreach (var tax in DivineTaxes)
        {
            if (tax.Culture != culture) continue;
            double tithe = localIncome * tax.TaxRate;
            Console.WriteLine($"\uD83D\uDCB8 {culture} doou {tithe:F2} moedas a {tax.Deity} no templo de {tax.TempleSettlement}");
        }
    }

    public static void TriggerHistoricEconomicEvent(string settlement, string eventType)
    {
        string message = eventType switch
        {
            "Era de Ouro" => $"{settlement} entrou em uma era de ouro, o comércio floresce.",
            "Queda Cultural" => $"{settlement} sofre recessão por colapso filosófico.",
            "Guerra Santa" => $"{settlement} muda produção para suportar cruzada espiritual.",
            _ => $"{settlement} sofreu um evento econômico."
        };

        Console.WriteLine($"\uD83D\uDCDC Evento Histórico: {message}");
    }
}
