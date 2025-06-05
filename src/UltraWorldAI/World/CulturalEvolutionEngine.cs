using System;

namespace UltraWorldAI.World;

public static class CulturalEvolutionEngine
{
    private static readonly Random Rand = new();

    public static void TickCulture(Settlement settlement)
    {
        int roll = Rand.Next(0, 100);

        if (roll < 10)
        {
            settlement.CultureSummary = "Nova Doutrina Emergente";
            SettlementHistoryTracker.Register(settlement.Name, "Mudança Cultural", "Nova doutrina filosófica surgida");
        }
        else if (roll < 20)
        {
            settlement.CultureSummary = "Reforma Espiritual Interna";
            SettlementHistoryTracker.Register(settlement.Name, "Transformação Religiosa", "Culto ancestral foi desafiado");
        }
        else if (roll < 30)
        {
            settlement.CultureSummary = "Fusão de Tradições";
            SettlementHistoryTracker.Register(settlement.Name, "Sincretismo Cultural", "Fusão de ritos com outra raça");
        }
    }
}
