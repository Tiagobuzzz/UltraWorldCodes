using System;
using System.Collections.Generic;

namespace UltraWorldAI.Biology;

/// <summary>
/// Simplified mechanic for fauna evolution over time.
/// </summary>
public static class FaunaEvolutionSystem
{
    private static readonly Dictionary<string, int> _population = new();

    public static void RegisterSpecies(string name, int initial)
    {
        _population[name] = initial;
    }

    public static void Evolve(string name)
    {
        if (!_population.ContainsKey(name)) return;
        int change = Random.Shared.Next(-2, 5);
        _population[name] = Math.Max(0, _population[name] + change);
    }

    public static int GetPopulation(string name) =>
        _population.GetValueOrDefault(name);
}
