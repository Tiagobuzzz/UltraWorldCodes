using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

/// <summary>
/// Basic stock market simulation with random price fluctuation.
/// </summary>
public static class StockMarketSystem
{
    private static readonly Dictionary<string, double> _prices = new();
    private static readonly Random _rnd = new();

    public static void RegisterStock(string symbol, double price)
    {
        _prices[symbol] = price;
    }

    public static void Tick()
    {
        foreach (var key in _prices.Keys.ToList())
        {
            var change = (_rnd.NextDouble() - 0.5) * 0.2 * _prices[key];
            _prices[key] = Math.Max(0.01, _prices[key] + change);
        }
    }

    public static double GetPrice(string symbol) =>
        _prices.TryGetValue(symbol, out var p) ? p : 0.0;
}
