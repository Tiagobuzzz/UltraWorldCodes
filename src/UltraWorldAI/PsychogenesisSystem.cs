using System;
using System.Collections.Generic;
using System.Linq;
using UltraWorldAI.Health;
using UltraWorldAI.World;

namespace UltraWorldAI;

public class CollectiveBelief
{
    public string Culture = string.Empty;
    public string Belief = string.Empty;
    public int BelieverCount;
    public float FaithStrength;
    public bool Manifested;
}

public static class PsychogenesisSystem
{
    public static List<CollectiveBelief> ActiveBeliefs { get; } = new();

    public static void RegisterBelief(string culture, string belief, float faithIncrement)
    {
        var cb = ActiveBeliefs.FirstOrDefault(b => b.Culture == culture && b.Belief == belief);
        if (cb == null)
        {
            cb = new CollectiveBelief
            {
                Culture = culture,
                Belief = belief,
                BelieverCount = 1,
                FaithStrength = faithIncrement,
                Manifested = false
            };
            ActiveBeliefs.Add(cb);
        }
        else
        {
            cb.BelieverCount++;
            cb.FaithStrength = MathF.Min(cb.FaithStrength + faithIncrement, 1f);
        }

        if (cb.FaithStrength >= 0.85f && !cb.Manifested)
        {
            cb.Manifested = true;
            Console.WriteLine($"\u2728 A cren\u00e7a '{cb.Belief}' da cultura '{cb.Culture}' se tornou real.");
            BeliefTerrainSystem.AlterRegion(cb.Culture, cb.Belief);
            FaithDiseaseSystem.ResolveByBelief(cb.Culture, cb.Belief);
        }

        PsychogenesisOverload.CheckForOverload(cb.Culture);
    }

    public static void Reset() => ActiveBeliefs.Clear();
}
