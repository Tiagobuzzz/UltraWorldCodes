using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class RoyalMember
{
    public string Name { get; set; } = string.Empty;
    public string House { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // "Rei", "Príncipe", "Bastardo", etc.
    public string Parent1 { get; set; } = string.Empty;
    public string Parent2 { get; set; } = string.Empty;
    public bool IsLegitimate { get; set; }
}

public static class DynastySystem
{
    public static List<RoyalMember> Members { get; } = new();

    public static void RegisterMember(string name, string house, string role, string p1, string p2, bool legit)
    {
        Members.Add(new RoyalMember
        {
            Name = name,
            House = house,
            Role = role,
            Parent1 = p1,
            Parent2 = p2,
            IsLegitimate = legit
        });

        string status = legit ? "legítimo" : "bastardo";
        Console.WriteLine($"🧬 {name} registrado na Casa {house} como {role} ({status})");
    }

    public static void PrintDynasty(string house)
    {
        Console.WriteLine($"\n🏰 Membros da Casa {house}:");
        foreach (var m in Members)
        {
            if (m.House == house)
                Console.WriteLine($"• {m.Role}: {m.Name} (Pais: {m.Parent1}, {m.Parent2}) | Legítimo? {m.IsLegitimate}");
        }
    }
}
