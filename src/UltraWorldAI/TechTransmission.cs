using System.Collections.Generic;

namespace UltraWorldAI.Discovery;

public static class TechTransmission
{
    public static Dictionary<string, List<string>> TechOwners { get; } = new();

    public static void ShareTech(string techName, string from, string to)
    {
        if (!TechOwners.ContainsKey(techName))
            TechOwners[techName] = new List<string>();

        if (!TechOwners[techName].Contains(to))
            TechOwners[techName].Add(to);
    }

    public static void StealTech(string techName, string thief)
    {
        ShareTech(techName, "Desconhecido", thief);
    }

    public static string WhoKnows(string techName)
    {
        if (!TechOwners.ContainsKey(techName)) return "Ninguém conhece.";
        return $"Conhecida por: {string.Join(", ", TechOwners[techName])}";
    }
}
