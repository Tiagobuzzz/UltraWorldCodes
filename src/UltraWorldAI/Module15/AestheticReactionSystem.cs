using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class AestheticProfile
{
    public string Name = string.Empty;
    public Dictionary<string, float> Sensitivities = new();
}

public static class AestheticReactionSystem
{
    public static List<AestheticProfile> Profiles { get; } = new();

    public static void RegisterProfile(string name, Dictionary<string, float> sensitivities)
    {
        Profiles.Add(new AestheticProfile
        {
            Name = name,
            Sensitivities = sensitivities
        });

        Console.WriteLine($"\uD83C\uDFA8 Est\u00E9tica de {name} registrada.");
    }

    public static float Evaluate(string name, Dictionary<string, float> stimulus)
    {
        var profile = Profiles.Find(p => p.Name == name);
        float total = 0;
        if (profile != null)
        {
            foreach (var s in stimulus)
            {
                if (profile.Sensitivities.ContainsKey(s.Key))
                    total += profile.Sensitivities[s.Key] * s.Value;
            }
        }
        return total;
    }
}
