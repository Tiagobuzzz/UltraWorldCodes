using System.Collections.Generic;

namespace UltraWorldAI;

/// <summary>
/// Relics influence beliefs of future generations.
/// </summary>
public class Relic
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, float> BeliefInfluence { get; set; } = new();
}

public static class RelicSystem
{
    public static List<Relic> Relics { get; } = new();

    public static void AddRelic(Relic relic) => Relics.Add(relic);

    public static void ApplyRelics(Person person)
    {
        foreach (var relic in Relics)
        {
            foreach (var kv in relic.BeliefInfluence)
            {
                person.Mind.Beliefs.UpdateBelief(kv.Key, kv.Value);
            }
        }
    }
}
