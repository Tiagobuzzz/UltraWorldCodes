using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class MysticLanguage
{
    public string Name { get; set; } = string.Empty;
    public string AccessMethod { get; set; } = string.Empty; // "Sonho" ou "Ritual"
    public double Complexity { get; set; }
}

public static class MysticLanguageSystem
{
    public static List<MysticLanguage> Languages { get; } = new();

    public static void Register(string name, string method, double complexity)
    {
        Languages.Add(new MysticLanguage
        {
            Name = name,
            AccessMethod = method,
            Complexity = complexity
        });
    }

    public static void AttemptUnderstanding(string name, string method, double focus)
    {
        var lang = Languages.Find(l => l.Name == name && l.AccessMethod == method);
        if (lang == null)
        {
            Console.WriteLine($"\u2753 Linguagem m\u00EDstica {name} n\u00E3o encontrada.");
            return;
        }

        double chance = focus - lang.Complexity;
        if (new Random().NextDouble() < chance)
            Console.WriteLine($"\uD83C\uDF19 Compreens\u00E3o de {name} alcan\u00E7ada atrav\u00E9s de {method}.");
        else
            Console.WriteLine($"\uD83D\uDCA5 Falha em compreender {name} no {method}.");
    }
}
