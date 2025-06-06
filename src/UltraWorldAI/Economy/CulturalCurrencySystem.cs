using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class CurrencyDefinition
{
    public string Culture { get; set; } = string.Empty;
    public string CurrencyName { get; set; } = string.Empty;
    public string BasedOn { get; set; } = string.Empty; // "Ouro", "Sal", "Cantos Sagrados", etc.
    public double ValueMultiplier { get; set; } // quanto vale em relação ao valor padrão
}

public static class CulturalCurrencySystem
{
    public static List<CurrencyDefinition> Currencies { get; } = new();

    public static void DefineCurrency(string culture, string name, string basedOn, double multiplier)
    {
        Currencies.Add(new CurrencyDefinition
        {
            Culture = culture,
            CurrencyName = name,
            BasedOn = basedOn,
            ValueMultiplier = multiplier
        });

        Console.WriteLine($"\uD83E\uDE99 Nova moeda: {name} ({culture}) baseada em {basedOn}, valor relativo: x{multiplier}");
    }

    public static void PrintCurrencies()
    {
        foreach (var c in Currencies)
            Console.WriteLine($"\n\uD83D\uDCB0 {c.Culture} usa {c.CurrencyName}, baseada em {c.BasedOn} | Valor: x{c.ValueMultiplier}");
    }
}
