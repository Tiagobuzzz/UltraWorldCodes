using System;
using System.Collections.Generic;

namespace UltraWorldAI;

public class CulturalMutation
{
    public string Culture = string.Empty;
    public string Mutation = string.Empty;
    public string OriginBelief = string.Empty;
    public string Effect = string.Empty;
}

public static class CulturalMutationSystem
{
    public static List<CulturalMutation> Mutations { get; } = new();

    public static void ApplyMutation(string culture, string mutation, string belief, string effect)
    {
        Mutations.Add(new CulturalMutation
        {
            Culture = culture,
            Mutation = mutation,
            OriginBelief = belief,
            Effect = effect
        });

        Console.WriteLine($"\uD83E\uDDEC A cultura '{culture}' sofreu muta\u00e7\u00e3o: {mutation} (cren\u00e7a: {belief}) \u2192 {effect}");
    }

    public static void Reset() => Mutations.Clear();
}
