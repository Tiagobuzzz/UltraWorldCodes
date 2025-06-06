using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public class Relic
{
    public string Name { get; set; } = string.Empty;
    public string AssociatedBelief { get; set; } = string.Empty;
    public float Influence { get; set; } = 0.1f;
}

public static class RelicSystem
{
    private static readonly List<Relic> _relics = new();

    public static void AddRelic(string name, string belief, float influence)
    {
        _relics.Add(new Relic { Name = name, AssociatedBelief = belief, Influence = influence });
    }

    public static void ApplyRelics(Person person)
    {
        foreach (var relic in _relics)
        {
            person.Mind.Beliefs.UpdateBelief(relic.AssociatedBelief, relic.Influence);
        }
    }
}
