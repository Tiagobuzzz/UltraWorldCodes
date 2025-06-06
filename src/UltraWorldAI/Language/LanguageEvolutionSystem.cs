using System;

namespace UltraWorldAI.Language;

/// <summary>
/// Evolves languages over time by applying random dialect shifts.
/// </summary>
public static class LanguageEvolutionSystem
{
    private static readonly Random _rand = new();

    public static void Evolve(LanguageSeed language)
    {
        if (_rand.NextDouble() < 0.5)
            DialectShiftEngine.EvolveDialect(language);
    }
}

