using System;
using System.Collections.Generic;
using UltraWorldAI.Biology;

namespace UltraWorldAI.Civilization;

public class SapientBeing
{
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public Genome GeneticCode { get; set; } = new();
    public int Age { get; set; }
    public string CurrentRegion { get; set; } = string.Empty;
    public string PersonalityType { get; set; } = string.Empty;
}

public static class IA_RaceLinker
{
    public static List<SapientBeing> Beings { get; } = new();

    public static void CreateBeing(string name, string raceName)
    {
        var race = RaceRepository.Races.Find(r => r.Name == raceName);
        if (race == null) throw new Exception("Raça não encontrada!");

        var genome = GenerateGenomeFromRace(race);
        string[] personalities = { "Impulsivo", "Paranoico", "Pacifista", "Calculista" };
        var rand = new Random();

        Beings.Add(new SapientBeing
        {
            Name = name,
            Race = race.Name,
            GeneticCode = genome,
            Age = 0,
            CurrentRegion = race.OriginBiome,
            PersonalityType = personalities[rand.Next(personalities.Length)]
        });
    }

    private static Genome GenerateGenomeFromRace(SapientRace race)
    {
        var genome = new Genome();

        foreach (var trait in race.DominantGenes)
        {
            genome.Genes.Add(new Gene
            {
                Trait = trait,
                AlleleA = trait.Substring(0, 1).ToUpper(),
                AlleleB = trait.Substring(0, 1).ToLower(),
                ExpressionType = AlleleType.Dominant
            });
        }

        foreach (var weakness in race.Weaknesses)
        {
            genome.Genes.Add(new Gene
            {
                Trait = weakness,
                AlleleA = "x",
                AlleleB = "x",
                ExpressionType = AlleleType.Recessive
            });
        }

        return genome;
    }
}
