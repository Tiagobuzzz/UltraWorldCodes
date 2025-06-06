using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class EconomicInstitution
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Founder { get; set; } = string.Empty;
    public List<string> SupportedDoctrines { get; set; } = new();
    public List<string> InternalFactions { get; set; } = new();
    public int CulturalInfluence { get; set; }
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
        var institution = new EconomicInstitution
        {
            Name = name,
            Location = location,
            Founder = founder,
            CulturalInfluence = 50,
            SupportedDoctrines = new List<string>(doctrines),
            InternalFactions = new List<string>(factions)
        };

        Institutions.Add(institution);
        Console.WriteLine($"\ud83c\udfdb\ufe0f Institui\u00e7\u00e3o criada: {name} em {location}, fundado por {founder}");
    }

    public static void ModifyInfluence(string name, int delta)
    {
        var inst = Institutions.Find(i => i.Name == name);
        if (inst == null) return;

        inst.CulturalInfluence = Math.Clamp(inst.CulturalInfluence + delta, 0, 100);
        Console.WriteLine($"\ud83d\udcc8 Influ\u00eancia cultural de {name}: {inst.CulturalInfluence}");
    }

    public static void PrintAll()
    {
        foreach (var i in Institutions)
        {
            Console.WriteLine($"\n\ud83c\udfeb {i.Name} | Local: {i.Location} | Fundador: {i.Founder}");
            Console.WriteLine($"\ud83d\udcda Doutrinas: {string.Join(", ", i.SupportedDoctrines)}");
            Console.WriteLine($"\u2694\ufe0f Fac\u00e7\u00f5es internas: {string.Join(" vs ", i.InternalFactions)}");
            Console.WriteLine($"\ud83d\udd25 Influ\u00eancia cultural: {i.CulturalInfluence}");
        }
    }
}
