using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Biology;

public class SpeciesLocus
{
    public string SpeciesName { get; set; } = string.Empty;
    public string OriginalRegion { get; set; } = string.Empty;
    public int GenerationCount { get; set; }
    public List<string> UniqueMutations { get; set; } = new();
    public List<string> RegionsWherePresent { get; set; } = new();
}

public static class GeneticWorldMap
{
    public static List<SpeciesLocus> Loci { get; } = new();

    public static void RegisterSpecies(Species species)
    {
        var locus = new SpeciesLocus
        {
            SpeciesName = species.Name,
            OriginalRegion = species.Biome,
            GenerationCount = species.GenerationsSurvived,
            UniqueMutations = species.Individuals
                .SelectMany(ind => ind.Genes.Where(g => g.DNAContainsMutation()).Select(g => g.Trait))
                .Distinct()
                .ToList(),
            RegionsWherePresent = new List<string> { species.Biome }
        };

        Loci.Add(locus);
    }

    public static void TrackMovement(Species species, string newRegion)
    {
        var locus = Loci.FirstOrDefault(l => l.SpeciesName == species.Name);
        if (locus != null && !locus.RegionsWherePresent.Contains(newRegion))
            locus.RegionsWherePresent.Add(newRegion);
    }

    public static string Summary()
    {
        return string.Join("\n\n", Loci.Select(l =>
            $"\uD83E\uDDEC Espécie: {l.SpeciesName}\nRegião Original: {l.OriginalRegion}\nPresente em: {string.Join(", ", l.RegionsWherePresent)}\nMut. únicas: {string.Join(", ", l.UniqueMutations)}\nGerações: {l.GenerationCount}"));
    }
}

public static class GeneExtensions
{
    public static bool DNAContainsMutation(this Gene gene)
    {
        return gene.AlleleA.Contains('M') || gene.AlleleB.Contains('M');
    }
}
