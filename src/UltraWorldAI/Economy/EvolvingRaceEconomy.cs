using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class RaceEconomicProfile
{
    public string Race { get; set; } = string.Empty;
    public string CurrentExchangeModel { get; set; } = string.Empty;
    public string DominantBiome { get; set; } = string.Empty;
    public List<string> PreferredGoods { get; set; } = new();
    public int EconomicLevel { get; set; }
}

public static class EvolvingRaceEconomy
{
    public static List<RaceEconomicProfile> Races { get; } = new();

    public static void RegisterRace(string race, string biome, string model)
    {
        if (Races.Exists(r => r.Race == race)) return;

        Races.Add(new RaceEconomicProfile
        {
            Race = race,
            DominantBiome = biome,
            CurrentExchangeModel = model,
            EconomicLevel = 20,
            PreferredGoods = GenerateInitialPreferences(biome)
        });

        Console.WriteLine($"\uD83C\uDF31 Raça {race} iniciou economia baseada em {model}, bioma: {biome}");
    }

    public static void EvolveEconomy(string race, bool contact, bool conflict, bool newTech)
    {
        var profile = Races.Find(r => r.Race == race);
        if (profile == null) return;

        int evolution = 0;
        if (contact) evolution += 10;
        if (conflict) evolution += 5;
        if (newTech) evolution += 15;

        profile.EconomicLevel = Math.Clamp(profile.EconomicLevel + evolution, 0, 100);

        if (profile.EconomicLevel > 70 && profile.CurrentExchangeModel == "Barter")
            profile.CurrentExchangeModel = "Moeda";
        else if (profile.EconomicLevel > 40 && profile.CurrentExchangeModel == "Serviço")
            profile.CurrentExchangeModel = "Prestígio";

        Console.WriteLine($"\uD83D\uDCC8 Raça {race} evoluiu economia: nível {profile.EconomicLevel}, modelo: {profile.CurrentExchangeModel}");
    }

    public static RaceEconomicProfile? GetProfile(string race) =>
        Races.Find(r => r.Race == race);

    private static List<string> GenerateInitialPreferences(string biome)
    {
        return biome switch
        {
            "Deserto" => new() { "Água", "Tecidos", "Especiarias" },
            "Floresta" => new() { "Madeira", "Frutas", "Artesanato" },
            "Montanha" => new() { "Minérios", "Pedras", "Runas" },
            _ => new() { "Comida", "Ferramentas" }
        };
    }

    public static void PrintAll()
    {
        foreach (var race in Races)
        {
            Console.WriteLine($"\uD83E\uDD16 {race.Race} | Modelo: {race.CurrentExchangeModel} | Nível: {race.EconomicLevel} | Bioma: {race.DominantBiome}");
        }
    }
}
