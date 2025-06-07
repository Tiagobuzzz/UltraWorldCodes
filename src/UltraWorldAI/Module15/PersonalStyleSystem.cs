using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class StyleProfile
{
    public string Name = string.Empty;
    public List<string> PreferredElements = new();
    public string DominantMood = string.Empty;
}

public static class PersonalStyleSystem
{
    public static List<StyleProfile> Styles { get; } = new();

    public static void DefineStyle(string name, List<string> elements, string mood)
    {
        Styles.Add(new StyleProfile
        {
            Name = name,
            PreferredElements = elements,
            DominantMood = mood
        });

        Console.WriteLine($"\uD83D\uDC57 Estilo de {name}: {string.Join(", ", elements)} | Clima: {mood}");
    }

    public static void PrintStyles()
    {
        foreach (var s in Styles)
            Console.WriteLine($"\uD83E\uDDF5 {s.Name} | Elementos: {string.Join(", ", s.PreferredElements)} | Estilo: {s.DominantMood}");
    }
}
