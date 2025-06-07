using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class MagicSchool
{
    public string Name = string.Empty;
    public string Culture = string.Empty;
    public string Doctrine = string.Empty; // "Ordem, Pureza, Controle", "Caos, Emoção, Intuição"
    public bool IsPersecuted;
}

public static class MagicCultureSystem
{
    public static List<MagicSchool> Schools { get; } = new();

    public static void RegisterSchool(string name, string culture, string doctrine, bool persecuted)
    {
        Schools.Add(new MagicSchool
        {
            Name = name,
            Culture = culture,
            Doctrine = doctrine,
            IsPersecuted = persecuted
        });

        Console.WriteLine($"\uD83D\uDCD9 Escola mágica: {name} | Cultura: {culture} | Doutrina: {doctrine} | Perseguida? {persecuted}");
    }

    public static void PrintSchools()
    {
        foreach (var s in Schools)
            Console.WriteLine($"\n\uD83C\uDFEB {s.Name} | Cultura: {s.Culture} | Doutrina: {s.Doctrine} | Perseguida: {s.IsPersecuted}");
    }
}
