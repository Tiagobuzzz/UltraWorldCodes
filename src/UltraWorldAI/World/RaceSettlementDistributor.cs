using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.Civilization;

namespace UltraWorldAI.World;

public class Settlement
{
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string CultureSummary { get; set; } = string.Empty;
    public int Population { get; set; }
    public int HousingUnits { get; set; }
    public string ArchitectureStyle { get; set; } = "Comum";
}

public static class RaceSettlementDistributor
{
    public static List<Settlement> Settlements { get; } = new();

    public static void GenerateSettlements(List<WorldRegion> regions)
    {
        var rand = new Random();

        foreach (var race in RaceRepository.Races)
        {
            var matches = regions
                .Where(r => r.Biome.Contains(race.OriginBiome.Split(' ')[0], StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matches.Count == 0)
            {
                matches = regions
                    .Where(r => r.Biome.Contains("Planície", StringComparison.OrdinalIgnoreCase) ||
                                 r.Biome.Contains("Floresta", StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (matches.Count == 0) continue;

            var region = matches[rand.Next(matches.Count)];
            var culture = RaceCultureSystem.GetForRace(race.Name);
            var name = $"{race.Name} de {region.Name}";

            Settlements.Add(new Settlement
            {
                Name = name,
                Region = region.Name,
                Race = race.Name,
                CultureSummary = culture?.SocialStructure ?? "Desconhecida",
                Population = rand.Next(200, 1000),
                HousingUnits = rand.Next(50, 300),
                ArchitectureStyle = rand.NextDouble() < 0.5 ? "Orgânica" : "Geométrica"
            });

            TerritoryClaimSystem.ClaimRegion(region.Name, race.Name, "Assentamento inicial");
        }
    }

    public static string DescribeAll()
    {
        if (Settlements.Count == 0) return "Nenhum assentamento criado.";
        return string.Join("\n\n", Settlements.Select(s =>
            $"\U0001F3D8️ {s.Name}\nRegião: {s.Region} | Raça: {s.Race}\nCultura: {s.CultureSummary}\nPopulação: {s.Population} | Habitações: {s.HousingUnits} | Arquitetura: {s.ArchitectureStyle}"));
    }
}
