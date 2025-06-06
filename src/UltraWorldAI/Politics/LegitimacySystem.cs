using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public enum LegitimacySource
{
    Sangue,
    Espirito,
    Povo,
    Medo,
    Riqueza,
    Conquista
}

public static class LegitimacySystem
{
    public static readonly Dictionary<string, Dictionary<LegitimacySource, float>> Legitimacy = new();

    public static void Register(string leader, LegitimacySource source, float value)
    {
        if (!Legitimacy.TryGetValue(leader, out var scores))
        {
            scores = new Dictionary<LegitimacySource, float>();
            Legitimacy[leader] = scores;
        }

        scores[source] = value;
    }

    public static float GetOverall(string leader)
    {
        if (!Legitimacy.TryGetValue(leader, out var scores) || scores.Count == 0)
            return 0f;

        float total = 0f;
        foreach (var val in scores.Values)
            total += val;
        return Math.Clamp(total / scores.Count, 0f, 1f);
    }
}
