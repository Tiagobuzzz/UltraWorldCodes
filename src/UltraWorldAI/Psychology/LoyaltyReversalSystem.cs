using System;
using System.Collections.Generic;

namespace UltraWorldAI.Psychology;

public class LoyaltyReversal
{
    public string AIName = string.Empty;
    public string FormerFaction = string.Empty;
    public string NewFaction = string.Empty;
    public string Reason = string.Empty;
}

public static class LoyaltyReversalSystem
{
    public static List<LoyaltyReversal> History { get; } = new();

    public static void ChangeSide(string aiName, string from, string to, string reason)
    {
        History.Add(new LoyaltyReversal
        {
            AIName = aiName,
            FormerFaction = from,
            NewFaction = to,
            Reason = reason
        });

        Console.WriteLine($"\uD83D\uDCD7 {aiName} deixou {from} por {to} ao descobrir: {reason}");
    }
}
