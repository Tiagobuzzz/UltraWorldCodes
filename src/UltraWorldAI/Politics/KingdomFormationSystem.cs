using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class ProtoAuthority
{
    public string FounderName { get; set; } = string.Empty;
    public string BaseLocation { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public int Supporters { get; set; }
    public string PowerBase { get; set; } = string.Empty; // "Militar", "Espiritual", etc.
    public bool CanFoundKingdom => Supporters >= 10 && !string.IsNullOrEmpty(PowerBase);
}

public static class KingdomFormationSystem
{
    public static List<ProtoAuthority> ProtoLeaders { get; } = new();
    public static List<string> FormedKingdoms { get; } = new();

    public static void EvaluateFormation()
    {
        foreach (var leader in ProtoLeaders)
        {
            if (leader.CanFoundKingdom && LegitimacySystem.GetOverall(leader.FounderName) >= 0.5f)
            {
                string kingdomName = $"Reino de {leader.FounderName}";
                if (!FormedKingdoms.Contains(kingdomName))
                {
                    FormedKingdoms.Add(kingdomName);
                    Console.WriteLine($"👑 {kingdomName} fundado em {leader.BaseLocation} por {leader.FounderName} ({leader.PowerBase})");
                }
            }
        }
    }

    public static void AddLeader(string name, string location, string culture, int supporters, string power)
    {
        ProtoLeaders.Add(new ProtoAuthority
        {
            FounderName = name,
            BaseLocation = location,
            Culture = culture,
            Supporters = supporters,
            PowerBase = power
        });
    }

    public static void PrintKingdoms()
    {
        Console.WriteLine("\n🌍 Reinos Formados:");
        foreach (var k in FormedKingdoms)
        {
            Console.WriteLine($"• {k}");
        }
    }
}
