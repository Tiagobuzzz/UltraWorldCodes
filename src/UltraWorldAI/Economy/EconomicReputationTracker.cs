using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class EconomicReputation
{
    public string Name { get; set; } = string.Empty;
    public double CreditRating { get; set; } = 50;
    public int FraudCount { get; set; }
    public int LoanSuccess { get; set; }
    public int LoanDefault { get; set; }
}

public static class EconomicReputationTracker
{
    public static List<EconomicReputation> Profiles { get; } = new();

    public static void Register(string name)
    {
        Profiles.Add(new EconomicReputation { Name = name });
    }

    public static void RecordLoanResult(string name, bool success)
    {
        var profile = Profiles.Find(p => p.Name == name);
        if (profile == null) return;

        if (success)
        {
            profile.LoanSuccess++;
            profile.CreditRating += 5;
        }
        else
        {
            profile.LoanDefault++;
            profile.CreditRating -= 10;
        }

        profile.CreditRating = Math.Clamp(profile.CreditRating, 0, 100);
    }

    public static void RecordFraud(string name)
    {
        var profile = Profiles.Find(p => p.Name == name);
        if (profile == null) return;

        profile.FraudCount++;
        profile.CreditRating -= 20;
        profile.CreditRating = Math.Clamp(profile.CreditRating, 0, 100);
    }

    public static string GetTrustStatus(string name)
    {
        var profile = Profiles.Find(p => p.Name == name);
        if (profile == null) return "Desconhecido";

        if (profile.CreditRating > 80) return "Confiável";
        if (profile.CreditRating > 50) return "Moderado";
        if (profile.CreditRating > 20) return "Desconfiado";
        return "Perigoso";
    }
}
