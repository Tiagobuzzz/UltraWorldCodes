using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.World;

public class EconomicNode
{
    public string Settlement { get; set; } = string.Empty;
    public double Wealth { get; set; }
    public bool HasMarket { get; set; }
    public bool HasTemple { get; set; }
    public string DominantFaith { get; set; } = string.Empty;
}

public class TradeLink
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Good { get; set; } = string.Empty;
    public double FlowAmount { get; set; }
}

public static class MapFaithEconomyIntegration
{
    public static List<EconomicNode> Nodes { get; } = new();
    public static List<TradeLink> TradeRoutes { get; } = new();

    public static void RegisterNode(string settlement, double wealth, bool market, bool temple, string faith)
    {
        var node = Nodes.FirstOrDefault(n => n.Settlement == settlement);
        if (node != null)
        {
            node.Wealth = wealth;
            node.HasMarket = market;
            node.HasTemple = temple;
            node.DominantFaith = faith;
        }
        else
        {
            Nodes.Add(new EconomicNode
            {
                Settlement = settlement,
                Wealth = wealth,
                HasMarket = market,
                HasTemple = temple,
                DominantFaith = faith
            });
        }

        SettlementHistoryTracker.Register(settlement, "Registro Econômico", "Assentamento mapeado para economia e fé.");
        Console.WriteLine($"\uD83D\uDCCD {settlement} adicionado ao mapa: mercado={market}, templo={temple}, fé={faith}");
    }

    public static void CreateTradeRoute(string from, string to, string good, double volume)
    {
        TradeRoutes.Add(new TradeLink
        {
            From = from,
            To = to,
            Good = good,
            FlowAmount = volume
        });

        SettlementHistoryTracker.Register(from, "Rota Comercial", $"Enviado {good} para {to} ({volume}).");
        Console.WriteLine($"\uD83D\uDCE6 Rota criada: {good} de {from} → {to} ({volume} unidades)");
    }

    public static void UpdateNodeWealth(string settlement, double delta)
    {
        var node = Nodes.FirstOrDefault(n => n.Settlement == settlement);
        if (node == null) return;

        node.Wealth = Math.Max(0, node.Wealth + delta);
        SettlementHistoryTracker.Register(settlement, "Mudança de Riqueza", $"Nova riqueza: {node.Wealth:F2}");
        Console.WriteLine($"\uD83D\uDCB0 {settlement} agora tem riqueza: {node.Wealth:F2}");
    }

    public static string GetMapOverview()
    {
        return string.Join('\n', Nodes.Select(n =>
            $"\uD83C\uDF0D {n.Settlement} | Riqueza: {n.Wealth:F1} | Fé: {n.DominantFaith} | Mercado: {n.HasMarket} | Templo: {n.HasTemple}"));
    }

    public static List<string> GetFaithZones(string deity)
    {
        return Nodes.Where(n => n.DominantFaith == deity).Select(n => n.Settlement).ToList();
    }

    public static double GetTradeVolume(string good)
    {
        return TradeRoutes.Where(r => r.Good == good).Sum(r => r.FlowAmount);
    }

    public static void InitializeFromSettlements()
    {
        foreach (var settlement in RaceSettlementDistributor.Settlements)
        {
            RegisterNode(
                settlement.Name,
                Random.Shared.Next(500, 1200),
                market: false,
                temple: false,
                faith: "Desconhecida");
        }
    }
}
