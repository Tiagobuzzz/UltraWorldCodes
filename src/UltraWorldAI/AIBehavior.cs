using System.Collections.Generic;

namespace UltraWorldAI;

public static class AIBehavior
{
    public static Dictionary<string, string> AvoidedZones { get; } = new();

    public static void AvoidZone(string zone, string reason)
    {
        AvoidedZones[zone] = reason;
    }
}
