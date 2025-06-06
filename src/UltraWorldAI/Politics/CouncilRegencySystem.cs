using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class CouncilMember
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // "Chanceler", "Guardião", "Oráculo"
    public bool IsLoyal { get; set; }
}

public class Regency
{
    public string Kingdom { get; set; } = string.Empty;
    public string Regent { get; set; } = string.Empty;
    public string Heir { get; set; } = string.Empty;
    public bool IsHeirOfAge { get; set; }
}

public static class CouncilRegencySystem
{
    public static List<CouncilMember> Council { get; } = new();
    public static List<Regency> Regencies { get; } = new();

    public static void AddCouncilMember(string name, string role, bool loyal)
    {
        Council.Add(new CouncilMember
        {
            Name = name,
            Role = role,
            IsLoyal = loyal
        });

        Console.WriteLine($"🏛️ {name} entrou no Conselho como {role} | Leal? {loyal}");
    }

    public static void DeclareRegency(string kingdom, string regent, string heir, bool heirOfAge)
    {
        Regencies.Add(new Regency
        {
            Kingdom = kingdom,
            Regent = regent,
            Heir = heir,
            IsHeirOfAge = heirOfAge
        });

        Console.WriteLine($"👶 {regent} assume regência de {kingdom} até {heir} atingir a maioridade.");
    }

    public static void PrintCouncil()
    {
        foreach (var c in Council)
            Console.WriteLine($"\n👥 {c.Name} | Cargo: {c.Role} | Leal? {c.IsLoyal}");
    }

    public static void PrintRegencies()
    {
        foreach (var r in Regencies)
            Console.WriteLine($"\n👑 Reino: {r.Kingdom} | Regente: {r.Regent} | Herdeiro: {r.Heir} | Maior de idade? {r.IsHeirOfAge}");
    }
}
