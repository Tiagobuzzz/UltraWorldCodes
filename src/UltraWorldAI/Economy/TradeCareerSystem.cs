using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class TradeRoute
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Good { get; set; } = string.Empty;
    public double Volume { get; set; }
}

public class TradeGuild
{
    public string Name { get; set; } = string.Empty;
    public List<string> ControlledSettlements { get; } = new();
    public double Wealth { get; set; }
}

public class Cryptocurrency
{
    public string Name { get; set; } = string.Empty;
    public double Value { get; set; }
    public double Volatility { get; set; } = 0.05; // percentage of change per update
}

public class EconomicCareer
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // Mercador, Contrabandista, Banqueiro
    public double Capital { get; set; }
    public string? GuildAffiliation { get; set; }
    public Dictionary<string, double> CryptoWallet { get; } = new();
}

public static class TradeCareerSystem
{
    public static List<TradeRoute> Routes { get; } = new();
    public static List<TradeGuild> Guilds { get; } = new();
    public static List<EconomicCareer> ActiveIAs { get; } = new();
    public static List<Cryptocurrency> Cryptocurrencies { get; } = new();

    public static void UpdateMarket()
    {
        foreach (var crypto in Cryptocurrencies)
        {
            var change = (Random.Shared.NextDouble() * 2 - 1) * crypto.Volatility;
            crypto.Value = Math.Max(0.01, crypto.Value * (1 + change));
        }
    }

    public static void CreateCareer(string iaName, string role)
    {
        var capital = Random.Shared.Next(100, 1000);
        ActiveIAs.Add(new EconomicCareer
        {
            Name = iaName,
            Role = role,
            Capital = capital
        });
    }

    public static void RegisterRoute(string origin, string destination, string good)
    {
        var route = new TradeRoute
        {
            Origin = origin,
            Destination = destination,
            Good = good,
            Volume = Random.Shared.Next(50, 200)
        };
        Routes.Add(route);
    }

    public static void CreateGuild(string name, string initialSettlement)
    {
        Guilds.Add(new TradeGuild
        {
            Name = name,
            Wealth = 1000,
            ControlledSettlements = { initialSettlement }
        });
    }

    public static void RegisterCryptocurrency(string name, double startingValue, double volatility = 0.05)
    {
        Cryptocurrencies.Add(new Cryptocurrency { Name = name, Value = startingValue, Volatility = volatility });
    }

    public static void TradeCrypto(EconomicCareer career, string crypto, double amount)
    {
        var currency = Cryptocurrencies.Find(c => c.Name == crypto);
        if (currency == null) return;
        if (!career.CryptoWallet.ContainsKey(crypto)) career.CryptoWallet[crypto] = 0;
        career.CryptoWallet[crypto] += amount;
        career.Capital -= amount * currency.Value;
    }

    public static void SimulateCryptoMarket()
    {
        foreach (var c in Cryptocurrencies)
        {
            var change = Random.Shared.NextDouble() * 0.1 - 0.05;
            c.Value = Math.Max(0.01, c.Value * (1 + change));
        }
    }
}
