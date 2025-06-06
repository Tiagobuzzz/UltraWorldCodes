using System.Collections.Generic;

namespace UltraWorldAI.Communication;

public class Rumor
{
    public string Content { get; set; } = string.Empty;
    public int SpreadCount { get; set; }
}

/// <summary>
/// Simple global communication network that propagates rumors.
/// </summary>
public static class RumorNetwork
{
    public static List<Rumor> Rumors { get; } = new();

    public static void Broadcast(string content)
    {
        Rumors.Add(new Rumor { Content = content, SpreadCount = 1 });
    }

    public static void Spread(Rumor rumor)
    {
        rumor.SpreadCount++;
    }
}
