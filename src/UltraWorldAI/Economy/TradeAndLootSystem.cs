using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class TradeTransaction
{
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Resource { get; set; } = string.Empty;
    public int Amount { get; set; }
    public string CurrencyUsed { get; set; } = string.Empty;
    public bool WasFair { get; set; }
}

public static class TradeAndLootSystem
{
    public static List<TradeTransaction> Transactions { get; } = new();

    public static void MakeTrade(string from, string to, string resource, int amount, string currency, bool fair)
    {
        Transactions.Add(new TradeTransaction
        {
            From = from,
            To = to,
            Resource = resource,
            Amount = amount,
            CurrencyUsed = currency,
            WasFair = fair
        });

        Console.WriteLine(fair
            ? $"\uD83E\uDD64 Troca justa: {from} \u279C {to} ({amount} de {resource} via {currency})"
            : $"\uD83D\uDC80 {from} explorou {to} (roubo velado de {amount} {resource} via {currency})");
    }

    public static void PrintTrades()
    {
        foreach (var t in Transactions)
            Console.WriteLine($"\n\uD83D\uDCE6 {t.From} \u2192 {t.To} | {t.Resource}: {t.Amount} via {t.CurrencyUsed} | Justa? {t.WasFair}");
    }
}
