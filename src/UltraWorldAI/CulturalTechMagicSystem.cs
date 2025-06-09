using System;
using System.Collections.Generic;

namespace UltraWorldAI;

public class CulturalTechnology
{
    public string CultureName { get; set; } = string.Empty;
    public string TechName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Arma, Ferramenta, Artefato Vivo, Infraestrutura
    public string MagicalProperty { get; set; } = string.Empty;
}

public static class CulturalTechMagicSystem
{
    public static List<CulturalTechnology> AllTech { get; } = new();

    public static void CreateTech(string culture, string belief, string philosophy)
    {
        string type = belief switch
        {
            "Purificação" => "Arma",
            "Expansão" => "Infraestrutura",
            "Equilíbrio" => "Artefato Vivo",
            _ => "Ferramenta"
        };

        string magicEffect = philosophy switch
        {
            "Controle" => "domina energia elemental",
            "Adaptação" => "muda forma com o ambiente",
            "Silêncio" => "é invisível quando não usada",
            "Revolução" => "explode após uso com poder simbólico",
            _ => "canaliza essência vital"
        };

        string techName = GenerateTechName(type);

        var tech = new CulturalTechnology
        {
            CultureName = culture,
            TechName = techName,
            Type = type,
            MagicalProperty = magicEffect,
            Description = $"{techName}, uma {type} criada por {culture}, que {magicEffect}."
        };

        AllTech.Add(tech);
        Console.WriteLine($"✨ [{culture}] criou: {techName} – {type} que {magicEffect}.");
    }

    private static string GenerateTechName(string type)
    {
        string[] baseWords = new[] { "Khal", "Rûn", "Vael", "Drom", "Seph", "Myrr", "Thal" };
        string suffix = type switch
        {
            "Arma" => "blade",
            "Ferramenta" => "core",
            "Artefato Vivo" => "seed",
            "Infraestrutura" => "spire",
            _ => "glyph"
        };

        return baseWords[RandomSingleton.Shared.Next(baseWords.Length)] + "-" + suffix;
    }
}
