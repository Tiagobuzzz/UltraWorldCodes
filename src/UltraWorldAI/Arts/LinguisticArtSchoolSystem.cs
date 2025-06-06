using System;
using System.Collections.Generic;

namespace UltraWorldAI.Arts;

public class ArtSchool
{
    public string Name { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty;
    public List<string> KnownFor { get; set; } = new();
    public List<string> Masters { get; set; } = new();
}

public static class LinguisticArtSchoolSystem
{
    public static List<ArtSchool> Schools { get; } = new();

    public static void CreateSchool(string name, string culture, string style, List<string> knownFor)
    {
        Schools.Add(new ArtSchool
        {
            Name = name,
            Culture = culture,
            Style = style,
            KnownFor = knownFor
        });

        Console.WriteLine($"\ud83c\udf93 Escola de arte criada: {name} | Cultura: {culture} | Estilo: {style}");
    }

    public static void AddMaster(string school, string masterName)
    {
        var s = Schools.Find(s => s.Name == school);
        s?.Masters.Add(masterName);
    }

    public static void PrintSchools()
    {
        foreach (var s in Schools)
        {
            Console.WriteLine($"\n\ud83c\udfad {s.Name} | Cultura: {s.Culture} | Estilo: {s.Style}");
            Console.WriteLine($"\ud83d\udcdc Conhecida por: {string.Join(", ", s.KnownFor)}");
            Console.WriteLine($"\ud83d\udc51 Mestres: {string.Join(", ", s.Masters)}");
        }
    }
}
