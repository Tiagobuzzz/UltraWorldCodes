using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class TaxPolicy
{
    public string Settlement { get; set; } = string.Empty;
    public double Rate { get; set; }
    public string Policy { get; set; } = "geral";
}

public static class TaxPolicySystem
{
    private static readonly Dictionary<string, TaxPolicy> _policies = new();

    public static void SetTax(string settlement, double rate, string policy = "geral")
    {
        _policies[settlement] = new TaxPolicy { Settlement = settlement, Rate = rate, Policy = policy };
    }

    public static double GetTaxRate(string settlement)
    {
        return _policies.TryGetValue(settlement, out var p) ? p.Rate : 0.0;
    }

    public static double ApplyTax(string settlement, double amount)
    {
        return amount * GetTaxRate(settlement);
    }
}
