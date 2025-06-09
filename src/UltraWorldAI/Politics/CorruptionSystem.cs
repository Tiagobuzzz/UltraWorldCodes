using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class CorruptionCase
{
    public string Suspect { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Investigated { get; set; }
    public bool Proven { get; set; }
}

public static class CorruptionSystem
{
    public static List<CorruptionCase> Cases { get; } = new();

    public static CorruptionCase ReportCase(string suspect, string description)
    {
        var c = new CorruptionCase { Suspect = suspect, Description = description };
        Cases.Add(c);
        return c;
    }

    public static void InvestigateAll()
    {
        foreach (var c in Cases)
        {
            if (c.Investigated) continue;
            c.Investigated = true;
            c.Proven = RandomSingleton.Shared.NextDouble() < 0.3;
        }
    }
}
