using System;
using UltraWorldAI.Civilization;

namespace UltraWorldAI.Interface;

/// <summary>
/// Simple console interface for creating custom races.
/// </summary>
public static class RaceCreationGui
{
    public static SapientRace CreateRace()
    {
        Console.Write("Nome da raça: ");
        var name = Console.ReadLine() ?? "Desconhecida";
        Console.Write("Bioma de origem: ");
        var biome = Console.ReadLine() ?? "N/A";

        var race = new SapientRace
        {
            Name = name,
            OriginBiome = biome
        };
        RaceRepository.Races.Add(race);
        return race;
    }
}
