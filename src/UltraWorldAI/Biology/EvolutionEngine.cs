using System;
using System.Collections.Generic;

namespace UltraWorldAI.Biology;

public static class EvolutionEngine
{
    public static void SimulateGeneration(Species species, string biome)
    {
        var nextGen = new List<Genome>();
        var rand = new Random();

        for (int i = 0; i < species.Individuals.Count - 1; i += 2)
        {
            var child = GeneticReproduction.CrossGenomes(species.Individuals[i], species.Individuals[i + 1]);
            GeneticMutation.Mutate(child);
            EpigeneticModulation.ApplyEnvironmentPressure(child, biome, rand.Next(0, 100));
            nextGen.Add(child);
        }

        species.Individuals = nextGen;
        species.GenerationsSurvived++;

        if (nextGen.Count < 5)
        {
            Console.WriteLine($"\u26A0\uFE0F Espécie {species.Name} entrou em risco de extinção.");
        }
    }
}
