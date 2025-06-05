using System;
using UltraWorldAI.Biology;

namespace UltraWorldAI.Civilization;

public static class InterRaceBreeding
{
    public static SapientBeing? Breed(SapientBeing a, SapientBeing b)
    {
        if (!RaceGeneticCompatibility.CanCross(a.Race, b.Race))
        {
            Console.WriteLine("⚠️ Raças incompatíveis. Reprodução falhou.");
            return null;
        }

        var childGenome = RaceGeneticCompatibility.CreateHybridGenome(a.GeneticCode, b.GeneticCode);

        return new SapientBeing
        {
            Name = $"{a.Name.Substring(0, 2)}{b.Name.Substring(0, 2)}-{DateTime.Now.Ticks % 1000}",
            Race = $"{a.Race}-{b.Race}",
            Age = 0,
            CurrentRegion = a.CurrentRegion,
            GeneticCode = childGenome
        };
    }
}
