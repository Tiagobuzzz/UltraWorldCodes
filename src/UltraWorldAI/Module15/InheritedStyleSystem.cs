using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class CulturalStyle
{
    public string Culture = string.Empty;
    public string AestheticSymbol = string.Empty;
    public List<string> InfluencedTraits = new();
}

public static class InheritedStyleSystem
{
    public static List<CulturalStyle> Styles { get; } = new();

    public static void AddStyle(string culture, string symbol, List<string> traits)
    {
        Styles.Add(new CulturalStyle
        {
            Culture = culture,
            AestheticSymbol = symbol,
            InfluencedTraits = traits
        });

        Console.WriteLine($"\uD83E\uDDE6 Estilo herdado: {culture} | S\u00edmbolo: {symbol} | Influ\u00eancia: {string.Join(", ", traits)}");
    }
}
