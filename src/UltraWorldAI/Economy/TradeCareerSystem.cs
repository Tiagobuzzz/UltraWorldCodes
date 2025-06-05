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

public class EconomicCareer
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // Mercador, Contrabandista, Banqueiro
    public double Capital { get; set; }
    public string? GuildAffiliation { get; set; }
}

public static class TradeCareerSystem
{
    public static List<TradeRoute> Routes { get; } = new();
    public static List<TradeGuild> Guilds { get; } = new();
    public static List<EconomicCareer> ActiveIAs { get; } = new();

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
}
