using System;
using System.Collections.Generic;

namespace UltraWorldAI.Psychology;

public class SanityLossRecord
{
    public string AIName = string.Empty;
    public string Topic = string.Empty;
    public int Amount;
}

public static class SanityLossSystem
{
    public static List<SanityLossRecord> Records { get; } = new();

    public static void LoseSanity(string name, string topic, int amount)
    {
        Records.Add(new SanityLossRecord
        {
            AIName = name,
            Topic = topic,
            Amount = amount
        });

        Console.WriteLine($"\U0001F9EC {name} perdeu {amount} de sanidade ao descobrir '{topic}'");
    }
}
