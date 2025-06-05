using System;
using System.Collections.Generic;

namespace UltraWorldAI.Biology;

public enum AlleleType
{
    Dominant,
    Recessive
}

public class Gene
{
    public string Trait { get; set; } = string.Empty;
    public string AlleleA { get; set; } = string.Empty;
    public string AlleleB { get; set; } = string.Empty;
    public AlleleType ExpressionType { get; set; }

    public string Expressed()
    {
        if (AlleleA == AlleleB)
            return AlleleA;
        if (ExpressionType == AlleleType.Dominant)
            return AlleleA == AlleleA.ToUpper() ? AlleleA : AlleleB;
        return AlleleA == AlleleA.ToLower() ? AlleleA : AlleleB;
    }
}

public class Genome
{
    public List<Gene> Genes { get; } = new();

    public string GetPhenotype()
    {
        return string.Join(", ", Genes.ConvertAll(g => $"{g.Trait}: {g.Expressed()}"));
    }
}

public static class GeneticReproduction
{
    public static Genome CrossGenomes(Genome parentA, Genome parentB)
    {
        var child = new Genome();
        var rand = new Random();

        for (int i = 0; i < parentA.Genes.Count; i++)
        {
            var geneA = parentA.Genes[i];
            var geneB = parentB.Genes[i];

            string alleleFromA = rand.NextDouble() > 0.5 ? geneA.AlleleA : geneA.AlleleB;
            string alleleFromB = rand.NextDouble() > 0.5 ? geneB.AlleleA : geneB.AlleleB;

            child.Genes.Add(new Gene
            {
                Trait = geneA.Trait,
                AlleleA = alleleFromA,
                AlleleB = alleleFromB,
                ExpressionType = geneA.ExpressionType
            });
        }

        return child;
    }
}

public static class GeneticMutation
{
    public static void Mutate(Genome genome, double mutationRate = 0.01)
    {
        var rand = new Random();

        foreach (var gene in genome.Genes)
        {
            if (rand.NextDouble() < mutationRate)
            {
                gene.AlleleA = MutateAllele(gene.AlleleA);
            }

            if (rand.NextDouble() < mutationRate)
            {
                gene.AlleleB = MutateAllele(gene.AlleleB);
            }
        }
    }

    private static string MutateAllele(string allele)
    {
        return allele == allele.ToUpper() ? allele.ToLower() : allele.ToUpper();
    }
}
