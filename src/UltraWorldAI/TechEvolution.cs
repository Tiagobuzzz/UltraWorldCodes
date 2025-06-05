using System;
using System.Collections.Generic;

namespace UltraWorldAI.Discovery;

public class EvolvingTech
{
    public ConceptualTech BaseTech { get; set; } = new();
    public List<ConceptualTech> Iterations { get; } = new();
}

public static class TechEvolution
{
    public static Dictionary<string, EvolvingTech> EvolutionMap { get; } = new();

    public static ConceptualTech IterateTech(ConceptualTech original, string modifierConcept)
    {
        var newConcepts = new List<string>(original.CombinedConcepts) { modifierConcept };
        var evolved = TechCreator.CreateTech(original.CreatedBy, newConcepts);

        if (!EvolutionMap.ContainsKey(original.Name))
            EvolutionMap[original.Name] = new EvolvingTech { BaseTech = original };

        EvolutionMap[original.Name].Iterations.Add(evolved);
        return evolved;
    }

    public static string DescribeEvolution(string baseTechName)
    {
        if (!EvolutionMap.ContainsKey(baseTechName))
            return "Tecnologia sem evolução registrada.";

        var e = EvolutionMap[baseTechName];
        var baseDesc = TechCreator.Describe(e.BaseTech);
        var iterations = string.Join("\n", e.Iterations.ConvertAll(TechCreator.Describe));
        return $"\uD83C\uDF31 Evolução de {baseTechName}:\n\n{baseDesc}\n\n\u2795 Iterações:\n{iterations}";
    }
}
