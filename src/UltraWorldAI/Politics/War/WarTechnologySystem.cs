using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics.War;

public static class WarTechnologySystem
{
    public static Dictionary<string, List<string>> TechByCulture { get; } = new();

    public static void UnlockTechnology(string culture)
    {
        if (!TechByCulture.ContainsKey(culture))
            TechByCulture[culture] = new List<string>();

        var newTech = GetNewTechIdea();
        TechByCulture[culture].Add(newTech);

        Console.WriteLine($"\u2699️ [{culture}] desenvolveu: {newTech}");
    }

    private static string GetNewTechIdea()
    {
        var ideas = new[]
        {
            "Armadura de Ossos Flexível",
            "Estilingue de Pólvora Negra",
            "Arpões Multiponto",
            "Cavalaria com Máscaras de Medo",
            "Bombas de Fumaça Natural",
            "Canhões de Som Ritual"
        };
        return ideas[new Random().Next(ideas.Length)];
    }
}
