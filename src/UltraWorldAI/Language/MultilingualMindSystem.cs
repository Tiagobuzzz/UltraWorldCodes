using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public static class MultilingualMindSystem
{
    public static readonly Dictionary<string, List<string>> LanguagesByIA = new();

    public static void TeachLanguage(string ia, string language)
    {
        if (!LanguagesByIA.TryGetValue(ia, out var list))
        {
            list = new List<string>();
            LanguagesByIA[ia] = list;
        }
        if (!list.Contains(language))
        {
            list.Add(language);
            LinguisticPersonalityInfluenceSystem.AssignToIA(ia, language);
        }
    }

    public static string AnalyzeState(string ia)
    {
        if (!LanguagesByIA.TryGetValue(ia, out var langs) || langs.Count == 0)
            return "Nenhum idioma";

        var effects = new HashSet<string>();
        foreach (var l in langs)
        {
            var traits = LinguisticPersonalityInfluenceSystem.LanguageTraits.Find(t => t.Language == l);
            if (traits != null)
                effects.Add(traits.CognitiveEffect);
        }

        return effects.Count > 1 ? "Conflito Interno" : langs.Count > 1 ? "Sabedoria M\u00faltipla" : "Est\u00e1vel";
    }
}
