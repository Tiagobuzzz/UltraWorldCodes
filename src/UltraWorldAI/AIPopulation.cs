using System.Collections.Generic;

namespace UltraWorldAI;

public static class AIPopulation
{
    public static Dictionary<string, List<string>> Behaviors { get; } = new();

    public static void AdaptBehavior(string group, string behavior)
    {
        if (!Behaviors.ContainsKey(group))
            Behaviors[group] = new List<string>();
        Behaviors[group].Add(behavior);
    }
}
