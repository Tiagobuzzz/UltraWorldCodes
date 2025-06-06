using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticArchitecture
{
    public string Civilization { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string ArchitectureStyle { get; set; } = string.Empty;
    public string WritingStyle { get; set; } = string.Empty;
    public string Cosmology { get; set; } = string.Empty;
}

public static class LinguisticArchitectureInfluenceSystem
{
    public static readonly List<LinguisticArchitecture> Designs = new();

    public static void DefineInfluence(string civ, string language, string architecture, string writing, string cosmology)
    {
        Designs.Add(new LinguisticArchitecture
        {
            Civilization = civ,
            Language = language,
            ArchitectureStyle = architecture,
            WritingStyle = writing,
            Cosmology = cosmology
        });
        Console.WriteLine($"\uD83C\uDFDB\uFE0F Civiliza\u00e7\u00e3o {civ} moldada pela l\u00edngua {language}.");
    }

    public static LinguisticArchitecture? GetInfluence(string civ) => Designs.Find(d => d.Civilization == civ);
}
