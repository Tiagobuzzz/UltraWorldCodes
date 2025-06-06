using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Economy;

public class EconomicPhilosophy
{
    public string Name { get; set; } = string.Empty;
    public string Founder { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public List<string> Principles { get; set; } = new();
    public List<string> PreferredActions { get; set; } = new();
    public int YearCreated { get; set; }
}

public static class EconomicPhilosophySystem
{
    public static List<EconomicPhilosophy> Schools { get; } = new();

    public static void CreateSchool(
        string name,
        string founder,
        string culture,
        int year,
        IEnumerable<string> principles,
        IEnumerable<string> actions)
    {
        if (Schools.Any(s => s.Name == name && s.Culture == culture)) return;

        var school = new EconomicPhilosophy
        {
            Name = name,
            Founder = founder,
            Culture = culture,
            YearCreated = year,
            Principles = new List<string>(principles),
            PreferredActions = new List<string>(actions)
        };

        Schools.Add(school);
        Console.WriteLine($"\ud83d\udcd3 Nova escola econ\u00f4mica criada: {name} ({culture}, ano {year})");
    }

    public static void PrintAllSchools()
    {
        foreach (var s in Schools)
        {
            Console.WriteLine($"\n\ud83d\udcd9 Escola: {s.Name} | Fundador: {s.Founder} | Cultura: {s.Culture} | Ano: {s.YearCreated}");
            Console.WriteLine($"\ud83e\udde0 Princ\u00edpios: {string.Join(", ", s.Principles)}");
            Console.WriteLine($"\ud83d\udd04 A\u00e7\u00f5es preferidas: {string.Join(", ", s.PreferredActions)}");
        }
    }

    public static List<string> GetSuggestionsForAI(string schoolName)
    {
        var school = Schools.FirstOrDefault(s => s.Name == schoolName);
        return school?.PreferredActions ?? new List<string>();
    }

    public static IEnumerable<EconomicPhilosophy> GetSchoolsByCulture(string culture) =>
        Schools.Where(s => s.Culture == culture);
}
