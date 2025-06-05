using System;

namespace UltraWorldAI.Biology;

public static class EpigeneticModulation
{
    public static void ApplyEnvironmentPressure(Genome genome, string biome, int stressLevel)
    {
        foreach (var gene in genome.Genes)
        {
            if (biome.Contains("Deserto") && gene.Trait == "Resist\u00EAncia T\u00E9rmica")
            {
                gene.AlleleA = "H";
                gene.AlleleB = "H";
            }

            if (biome.Contains("Floresta") && gene.Trait == "Vis\u00E3o")
            {
                gene.AlleleA = "N";
            }

            if (stressLevel > 80 && gene.Trait == "Adrenalina")
            {
                gene.AlleleA = "A";
                gene.AlleleB = "A";
            }
        }
    }
}
