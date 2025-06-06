using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Doctrine;

public class MarketPolicy
{
    public string Culture { get; set; } = string.Empty;
    public string Doctrine { get; set; } = string.Empty;
    public List<string> BannedProducts { get; set; } = new();
    public List<string> SacredGoods { get; set; } = new();
    public double TaxRate { get; set; }
}

public static class DoctrinalMarketSystem
{
    public static List<MarketPolicy> Policies { get; } = new();

    public static void ApplyDoctrine(
        string culture,
        string doctrine,
        List<string> banned,
        List<string> sacred,
        double tax)
    {
        Policies.Add(new MarketPolicy
        {
            Culture = culture,
            Doctrine = doctrine,
            BannedProducts = banned,
            SacredGoods = sacred,
            TaxRate = tax
        });

        Console.WriteLine($"\ud83d\udce6 {culture} aplicou a doutrina {doctrine}:");
        Console.WriteLine($"\ud83d\udeab Proibidos: {string.Join(", ", banned)} | \u2728 Sagrados: {string.Join(", ", sacred)} | \ud83d\udcb0 Taxa: {tax * 100}%");
    }

    public static bool IsProductAllowed(string culture, string product)
    {
        var policy = Policies.FirstOrDefault(p => p.Culture == culture);
        return policy == null || !policy.BannedProducts.Contains(product);
    }

    public static double GetTaxRate(string culture, string product)
    {
        var policy = Policies.FirstOrDefault(p => p.Culture == culture);
        if (policy == null) return 0.1;
        return policy.SacredGoods.Contains(product) ? 0.0 : policy.TaxRate;
    }
}
