using System.Collections.Generic;

namespace UltraWorldAI.Biology;

public class Species
{
    public string Name { get; set; } = string.Empty;
    public List<Genome> Individuals { get; set; } = new();
    public string Biome { get; set; } = string.Empty;
    public int GenerationsSurvived { get; set; }

    public Genome AverageGenome()
    {
        // Simplified: return first individual's genome for demo purposes
        return Individuals.Count > 0 ? Individuals[0] : new Genome();
    }
}
