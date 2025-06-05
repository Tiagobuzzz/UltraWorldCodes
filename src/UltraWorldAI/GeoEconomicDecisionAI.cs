using System;
using System.Linq;
using UltraWorldAI.World;

namespace UltraWorldAI;

public static class GeoEconomicDecisionAI
{
    public static void EvaluateSettlement(string iaName, string currentLocation, string faith, double wealth)
    {
        var richer = MapFaithEconomyIntegration.Nodes
            .Where(n => n.Wealth > wealth + 200)
            .OrderByDescending(n => n.Wealth)
            .FirstOrDefault();

        if (richer != null)
        {
            SettlementHistoryTracker.Register(currentLocation, "Migração", $"{iaName} mudou-se para {richer.Settlement}");
            Console.WriteLine($"\uD83C\uDFC3 {iaName} migrou de {currentLocation} para {richer.Settlement} buscando prosperidade.");
        }

        var dominantFaith = MapFaithEconomyIntegration.Nodes
            .Where(n => n.Settlement == currentLocation)
            .Select(n => n.DominantFaith)
            .FirstOrDefault();

        if (!string.IsNullOrEmpty(dominantFaith) && dominantFaith != faith)
        {
            SettlementHistoryTracker.Register(currentLocation, "Conversão", $"{iaName} adotou a fé {dominantFaith}");
            Console.WriteLine($"\u26EA {iaName} converteu-se de {faith} para {dominantFaith} em {currentLocation}.");
        }

        var target = MapFaithEconomyIntegration.Nodes
            .Where(n => n.Wealth > 1000 && n.DominantFaith != faith)
            .OrderByDescending(n => n.Wealth)
            .FirstOrDefault();

        if (target != null)
        {
            SettlementHistoryTracker.Register(target.Settlement, "Conflito Econômico", $"{iaName} tenta dominar o mercado");
            Console.WriteLine($"\u2694\uFE0F {iaName} lidera investida econômica contra {target.Settlement}, tentando tomar controle.");
        }
    }
}
