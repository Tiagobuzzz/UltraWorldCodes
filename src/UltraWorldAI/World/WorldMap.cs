using System.Collections.Generic;

namespace UltraWorldAI.World;

public static class WorldMap
{
    public static List<string> Landmarks { get; } = new();

    public static void AddLandmark(string name, bool isDivine = false)
    {
        Landmarks.Add(isDivine ? $"{name} (divino)" : name);
    }
}
