using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class Loan
{
    public string Debtor { get; set; } = string.Empty;
    public string Creditor { get; set; } = string.Empty;
    public double Amount { get; set; }
    public int TurnsLeft { get; set; }
}

public static class BankingCollapseSystem
{
    public static List<Loan> Loans { get; } = new();
    public static Dictionary<string, double> BankWealth { get; } = new();
    public static HashSet<string> FailedBanks { get; } = new();

    public static void GiveLoan(string bank, string debtor, double amount, int duration)
    {
        if (!BankWealth.ContainsKey(bank))
            BankWealth[bank] = 1000;

        if (BankWealth[bank] < amount)
        {
            Console.WriteLine($"💥 Banco {bank} quebrou ao tentar emprestar mais do que tem!");
            return;
        }

        Loans.Add(new Loan
        {
            Debtor = debtor,
            Creditor = bank,
            Amount = amount,
            TurnsLeft = duration
        });

        BankWealth[bank] -= amount;
    }

    public static void AdvanceLoans()
    {
        foreach (var loan in Loans.ToArray())
        {
            loan.TurnsLeft--;
            if (loan.TurnsLeft <= 0)
            {
                bool defaulted = Random.Shared.NextDouble() < 0.3;
                if (defaulted)
                {
                    BankWealth[loan.Creditor] -= loan.Amount;
                }
                else
                {
                    BankWealth[loan.Creditor] += loan.Amount * 1.2;
                }
            }
        }

        Loans.RemoveAll(l => l.TurnsLeft <= 0);
        CascadeFailures();
    }

    private static void CascadeFailures()
    {
        bool newFailure;
        do
        {
            newFailure = false;
            foreach (var kv in BankWealth)
            {
                if (kv.Value < 0 && !FailedBanks.Contains(kv.Key))
                {
                    FailedBanks.Add(kv.Key);
                    newFailure = true;
                    foreach (var loan in Loans.Where(l => l.Creditor == kv.Key))
                    {
                        BankWealth[loan.Debtor] -= loan.Amount;
                    }
                }
            }
        } while (newFailure);
    }
}
