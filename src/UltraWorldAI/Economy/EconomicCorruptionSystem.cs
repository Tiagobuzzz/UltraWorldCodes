using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class MarketGuild
{
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public bool IsLegal { get; set; }
}

public class TaxPolicy
{
    public string Kingdom { get; set; } = string.Empty;
    public string ResourceTaxed { get; set; } = string.Empty;
    public double Rate { get; set; }
}

public class InflationIndex
{
    public string Currency { get; set; } = string.Empty;
    public double InflationRate { get; set; }
}

public static class EconomicCorruptionSystem
{
    public static List<MarketGuild> Guilds { get; } = new();
    public static List<TaxPolicy> Taxes { get; } = new();
    public static List<InflationIndex> Inflation { get; } = new();

    public static void CreateGuild(string name, string type, bool legal)
    {
        Guilds.Add(new MarketGuild { Name = name, Specialization = type, IsLegal = legal });
        var status = legal ? "Guilda" : "Guilda ilegal";
        Logger.Log($"[{status}] {name} - Setor: {type}");
    }

    public static void SetTax(string kingdom, string resource, double rate)
    {
        Taxes.Add(new TaxPolicy { Kingdom = kingdom, ResourceTaxed = resource, Rate = rate });
        Logger.Log($"[Imposto] {kingdom} taxa {resource} em {rate * 100}%");
    }

    public static void UpdateInflation(string currency, double rate)
    {
        Inflation.Add(new InflationIndex { Currency = currency, InflationRate = rate });
        Logger.Log($"[Inflacao] {currency} em {rate * 100}%");
    }

    public static IReadOnlyList<MarketGuild> ListGuilds() => Guilds;
    public static IReadOnlyList<TaxPolicy> ListTaxes() => Taxes;
    public static IReadOnlyList<InflationIndex> ListInflation() => Inflation;
}
