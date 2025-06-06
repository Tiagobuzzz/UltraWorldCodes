using System;
using System.Collections.Generic;
using UltraWorldAI.Politics;
using UltraWorldAI.Doctrine;

namespace UltraWorldAI.Doctrine;

public class SecretOrder
{
    public string Name = string.Empty;
    public string Doctrine = string.Empty;
    public string Founder = string.Empty;
    public string BaseCity = string.Empty;
    public List<string> Members = new();
    public List<string> Objectives = new();
    public bool IsDiscovered;
    public int InfluenceLevel; // 0-100
}

public static class SecretDoctrineNetworkSystem
{
    public static List<SecretOrder> Orders { get; } = new();

    public static SecretOrder CreateOrder(
        string name,
        string doctrine,
        string founder,
        string city,
        IEnumerable<string> goals)
    {
        var order = new SecretOrder
        {
            Name = name,
            Doctrine = doctrine,
            Founder = founder,
            BaseCity = city,
            Objectives = new List<string>(goals),
            InfluenceLevel = 20
        };

        Orders.Add(order);
        Console.WriteLine($"\uD83D\uDD73\uFE0F Ordem Secreta criada: {name} | Doutrina: {doctrine} | Base: {city}");
        return order;
    }

    public static void AddMember(string orderName, string member)
    {
        var o = Orders.Find(x => x.Name == orderName);
        if (o != null && !o.Members.Contains(member))
            o.Members.Add(member);
    }

    public static void SpreadInfluence(string orderName, int delta)
    {
        var o = Orders.Find(x => x.Name == orderName);
        if (o != null)
        {
            o.InfluenceLevel = Math.Clamp(o.InfluenceLevel + delta, 0, 100);
            Console.WriteLine($"\uD83D\uDCC8 Influ\u00eancia de {orderName} agora em {o.InfluenceLevel}");
        }
    }

    public static void DiscoverOrder(string orderName)
    {
        var o = Orders.Find(x => x.Name == orderName);
        if (o != null && !o.IsDiscovered)
        {
            o.IsDiscovered = true;
            Console.WriteLine($"\uD83D\uDEA8 ORDEM SECRETA DESCOBERTA: {orderName} em {o.BaseCity}!");
        }
    }

    public static void OrchestrateCoup(
        string orderName,
        int year,
        string region,
        string from,
        string to)
    {
        SpreadInfluence(orderName, 40);
        RegimeShiftSystem.AddEvent(year, region, from, to);
        Console.WriteLine($"\u2694\uFE0F Golpe de estado orquestrado por {orderName} em {region}");
    }

    public static void InciteRevolution(string orderName, int year, string cause)
    {
        SpreadInfluence(orderName, 20);
        RevolutionPatternDetector.AddEvent(year, cause);
        Console.WriteLine($"\u2694\uFE0F Revolu\u00e7\u00e3o iniciada por {orderName}: {cause}");
    }

    public static void StageIdeologicalAttack(
        string orderName,
        string target,
        int year,
        string description)
    {
        DoctrinalPoliticalInfluence.RegisterInfluence(
            orderName,
            "Atentado Ideol\u00f3gico",
            target,
            description,
            year);
    }

    public static void PrintOrders()
    {
        foreach (var o in Orders)
        {
            Console.WriteLine($"\n\uD83D\uDD73\uFE0F {o.Name} | Doutrina: {o.Doctrine} | Base: {o.BaseCity} | Fundador: {o.Founder}");
            Console.WriteLine($"\uD83C\uDFAF Objetivos: {string.Join(", ", o.Objectives)}");
            Console.WriteLine($"\uD83D\uDC65 Membros: {string.Join(", ", o.Members)}");
            Console.WriteLine($"\uD83D\uDCC9 Descoberta: {(o.IsDiscovered ? "Sim" : "N\u00e3o")} | Influ\u00eancia: {o.InfluenceLevel}");
        }
    }
}
