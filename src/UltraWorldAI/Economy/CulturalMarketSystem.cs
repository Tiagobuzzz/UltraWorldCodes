using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class CulturalPreference
{
    public string Culture { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public List<string> PreferredGoods { get; set; } = new();
    public List<string> TabooGoods { get; set; } = new();
    public string ExchangeModel { get; set; } = string.Empty;
}

public static class CulturalMarketSystem
{
    public static List<CulturalPreference> Preferences { get; } = new();

    public static void RegisterCulture(string culture, string race, string exchange)
    {
        Preferences.Add(new CulturalPreference
        {
            Culture = culture,
            Race = race,
            ExchangeModel = exchange,
            PreferredGoods = GenerateGoods(exchange, true),
            TabooGoods = GenerateGoods(exchange, false)
        });
    }

    private static List<string> GenerateGoods(string model, bool preferred)
    {
        if (model == "Oferta Ritual")
            return preferred
                ? new() { "Arte", "Runas", "Animais Raros" }
                : new() { "Ferro", "Moeda" };
        if (model == "Prestígio")
            return preferred
                ? new() { "História", "Títulos", "Serviços" }
                : new() { "Alimentos Básicos" };
        if (model == "Serviço")
            return preferred
                ? new() { "Trabalho", "Troca de Conhecimento" }
                : new() { "Tesouros" };
        return preferred
            ? new() { "Moeda", "Comida", "Ferramentas" }
            : new List<string>();
    }

    public static bool CanTrade(string culture, string good)
    {
        var pref = Preferences.Find(p => p.Culture == culture);
        if (pref == null) return false;
        return !pref.TabooGoods.Contains(good);
    }
}
