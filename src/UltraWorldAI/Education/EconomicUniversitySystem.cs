using System;
using System.Collections.Generic;
using UltraWorldAI.Economy;

namespace UltraWorldAI.Education;

public class EconomicInstitution
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Founder { get; set; } = string.Empty;
    public List<string> SupportedDoctrines { get; set; } = new();
    public List<string> InternalFactions { get; set; } = new();
    public int CulturalInfluence { get; set; } = 50; // 0-100
}

public static class EconomicUniversitySystem
{
    public static List<EconomicInstitution> Institutions { get; } = new();

    public static void CreateInstitution(
        string name,
        string location,
        string founder,
        IEnumerable<string> doctrines,
        IEnumerable<string> factions)
    {
        var inst = new EconomicInstitution
        {
            Name = name,
            Location = location,
            Founder = founder,
            SupportedDoctrines = new List<string>(doctrines),
            InternalFactions = new List<string>(factions)
        };
        Institutions.Add(inst);
        Console.WriteLine($"🏛️ Instituição criada: {name} em {location}, fundado por {founder}");
    }

    public static void ModifyInfluence(string name, int delta, bool propagate = true)
    {
        var inst = Institutions.Find(i => i.Name == name);
        if (inst == null) return;

        inst.CulturalInfluence = Math.Clamp(inst.CulturalInfluence + delta, 0, 100);
        Console.WriteLine($"📈 Influência cultural de {name}: {inst.CulturalInfluence}");

        if (propagate && inst.CulturalInfluence >= 80 && inst.SupportedDoctrines.Count > 0)
        {
            PhilosophySpreadSystem.PropagateToCulture(inst.SupportedDoctrines[0], inst.Location, 5);
        }
    }

    public static void PrintAll()
    {
        foreach (var i in Institutions)
        {
            Console.WriteLine($"\n🏫 {i.Name} | Local: {i.Location} | Fundador: {i.Founder}");
            Console.WriteLine($"📚 Doutrinas: {string.Join(", ", i.SupportedDoctrines)}");
            Console.WriteLine($"⚔️ Facções internas: {string.Join(" vs ", i.InternalFactions)}");
            Console.WriteLine($"🔥 Influência cultural: {i.CulturalInfluence}");
        }
    }
}
