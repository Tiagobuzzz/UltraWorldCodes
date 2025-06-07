using System;
using System.Collections.Generic;

namespace UltraWorldAI.Relationships;

public class EmotionalBond
{
    public string PersonA = string.Empty;
    public string PersonB = string.Empty;
    public string BondType = string.Empty;
    public int TrustLevel;
    public bool Broken;
    public string BreakReason = string.Empty;
}

public static class DeepBondAndHeartbreakSystem
{
    public static List<EmotionalBond> Bonds { get; } = new();

    public static void CreateBond(string a, string b, string type, int trust)
    {
        Bonds.Add(new EmotionalBond
        {
            PersonA = a,
            PersonB = b,
            BondType = type,
            TrustLevel = trust,
            Broken = false,
            BreakReason = string.Empty
        });

        Console.WriteLine($"\uD83D\uDC9E Bond between {a} and {b} | Type: {type} | Trust: {trust}");
    }

    public static void BreakBond(string a, string b, string reason)
    {
        var bond = Bonds.Find(x => x.PersonA == a && x.PersonB == b && !x.Broken);
        if (bond != null)
        {
            bond.Broken = true;
            bond.BreakReason = reason;
            Console.WriteLine($"\uD83D\uDC94 {a} and {b} broke the bond. Reason: {reason}");
        }
    }
}
