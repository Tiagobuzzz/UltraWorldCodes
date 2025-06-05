using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.World;

namespace UltraWorldAI;

public class PlacedTechnology
{
    public CulturalTechnology Tech { get; set; } = new();
    public string Location { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
}

public static class TechMapIntegration
{
    public static List<PlacedTechnology> TechOnMap { get; } = new();

    public static void PlaceTechnology(CulturalTechnology tech, string location, bool isPublic = false)
    {
        TechOnMap.Add(new PlacedTechnology
        {
            Tech = tech,
            Location = location,
            IsPublic = isPublic
        });

        SettlementHistoryTracker.Register(location, "Tecnologia Instalada", $"{tech.TechName} foi posicionada aqui.");
    }

    public static void AttemptSteal(string attacker, string targetLocation)
    {
        var techs = TechOnMap.Where(t => t.Location == targetLocation).ToList();
        foreach (var tech in techs)
        {
            if (Random.Shared.NextDouble() < 0.4)
            {
                tech.Location = attacker;
                tech.IsPublic = false;
                SettlementHistoryTracker.Register(attacker, "Roubo de Tecnologia", $"{tech.Tech.TechName} foi roubada de {targetLocation}!");
            }
        }
    }

    public static void AttemptImitation(string imitator, string targetLocation)
    {
        var techs = TechOnMap.Where(t => t.Location == targetLocation && t.IsPublic).ToList();
        foreach (var tech in techs)
        {
            if (Random.Shared.NextDouble() < 0.5)
            {
                var imitation = new CulturalTechnology
                {
                    CultureName = imitator,
                    TechName = $"Imitação de {tech.Tech.TechName}",
                    Type = tech.Tech.Type,
                    MagicalProperty = tech.Tech.MagicalProperty,
                    Description = $"Versão imitada de {tech.Tech.TechName}, criada por {imitator}"
                };
                CulturalTechMagicSystem.AllTech.Add(imitation);
                PlaceTechnology(imitation, imitator, true);
                SettlementHistoryTracker.Register(imitator, "Tecnologia Imitada", $"Criaram uma cópia de {tech.Tech.TechName}.");
            }
        }
    }

    public static void AttemptDestruction(string targetLocation)
    {
        var techs = TechOnMap.Where(t => t.Location == targetLocation).ToList();
        foreach (var tech in techs)
        {
            if (Random.Shared.NextDouble() < 0.3)
            {
                TechOnMap.Remove(tech);
                SettlementHistoryTracker.Register(targetLocation, "Tecnologia Destruída", $"{tech.Tech.TechName} foi destruída!");
            }
        }
    }
}
