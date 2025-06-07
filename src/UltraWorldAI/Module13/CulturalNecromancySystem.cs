using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class NecromancyTradition
{
    public string Culture { get; set; } = string.Empty;
    public string Viewpoint { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public bool IsLegallyAccepted { get; set; }
}

public static class CulturalNecromancySystem
{
    public static List<NecromancyTradition> Traditions { get; } = new();

    public static void AddTradition(string culture, string view, string method, bool legal)
    {
        Traditions.Add(new NecromancyTradition
        {
            Culture = culture,
            Viewpoint = view,
            Method = method,
            IsLegallyAccepted = legal
        });

        Console.WriteLine($"\u2620\uFE0F Necromancia: {culture} | Vis\u00E3o: {view} | M\u00E9todo: {method} | Legal: {legal}");
    }

    public static void PrintTraditions()
    {
        foreach (var t in Traditions)
            Console.WriteLine($"\n\uD83D\uDC80 Cultura: {t.Culture} | Vis\u00E3o: {t.Viewpoint} | M\u00E9todo: {t.Method} | Permitida? {t.IsLegallyAccepted}");
    }
}

