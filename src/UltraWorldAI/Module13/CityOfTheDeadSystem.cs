using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class CityOfTheDead
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public bool IsInteractive { get; set; }
    public List<string> BuriedSouls { get; set; } = new();
}

public static class CityOfTheDeadSystem
{
    public static List<CityOfTheDead> Cities { get; } = new();

    public static void CreateCity(string name, string location, string culture, bool interactive, List<string> souls)
    {
        Cities.Add(new CityOfTheDead
        {
            Name = name,
            Location = location,
            Culture = culture,
            IsInteractive = interactive,
            BuriedSouls = souls
        });

        Console.WriteLine($"\uD83C\uDFDB\uFE0F Cidade dos Mortos: {name} | Local: {location} | Cultura: {culture} | Interativa: {interactive}");
    }

    public static void PrintCities()
    {
        foreach (var c in Cities)
            Console.WriteLine($"\n\uD83D\uDEA7 {c.Name} | Cultura: {c.Culture} | Interativa? {c.IsInteractive} | Almas: {string.Join(", ", c.BuriedSouls)}");
    }
}

