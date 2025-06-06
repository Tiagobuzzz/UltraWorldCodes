using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public static class MassManipulationSystem
{
    private static readonly Dictionary<string, float> _influence = new();

    public static void Propagate(string population, string message, float intensity)
    {
        if (!_influence.ContainsKey(population))
            _influence[population] = 0f;
        _influence[population] += intensity;
        Logger.Log($"[Propaganda] {message} aplicado em {population}", LogLevel.Info);
    }

    public static float GetInfluence(string population) => _influence.GetValueOrDefault(population);
}
