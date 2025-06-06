using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class SacredLanguage
{
    public string Name { get; set; } = string.Empty;
    public List<string> AcceptedForms { get; set; } = new();
}

public static class SacredLanguageEvolutionSystem
{
    public static readonly List<SacredLanguage> Languages = new();

    public static void Register(string name, IEnumerable<string> forms)
    {
        Languages.Add(new SacredLanguage { Name = name, AcceptedForms = new List<string>(forms) });
    }

    public static bool Evolve(string name, string newForm)
    {
        var lang = Languages.Find(l => l.Name == name);
        if (lang == null) return false;
        var heresy = !lang.AcceptedForms.Contains(newForm);
        if (heresy)
            Console.WriteLine($"\u26A0\uFE0F Heresia lingu\u00edstica em {name}: {newForm}");
        lang.AcceptedForms.Add(newForm);
        return heresy;
    }
}
