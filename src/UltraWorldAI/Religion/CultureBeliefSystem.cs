using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public static class CultureBeliefSystem
{
    private static readonly Dictionary<string, string> Beliefs = new()
    {
        ["Humanos"] = "Expansão",
        ["Elfos"] = "Equilíbrio",
        ["Anões"] = "Purificação",
        ["Gigantes"] = "Ordem",
        ["Reptilianos"] = "Supremacia",
        ["Fae"] = "Caos"
    };

    public static string GetBelief(string race)
    {
        return Beliefs.TryGetValue(race, out var belief) ? belief : "Paz";
    }
}
