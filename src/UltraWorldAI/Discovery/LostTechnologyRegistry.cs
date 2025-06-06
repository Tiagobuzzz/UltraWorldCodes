using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Discovery;

public class LostTech
{
    public string Name { get; set; } = string.Empty;
    public int YearLost { get; set; }
}

public static class LostTechnologyRegistry
{
    public static List<LostTech> Lost { get; } = new();

    public static void RegisterLost(string name, int year)
    {
        Lost.Add(new LostTech { Name = name, YearLost = year });
    }

    public static bool Rediscover(string name)
    {
        var tech = Lost.FirstOrDefault(t => t.Name == name);
        if (tech == null) return false;
        Lost.Remove(tech);
        return true;
    }
}
