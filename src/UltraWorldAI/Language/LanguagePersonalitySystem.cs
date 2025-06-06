using System.Collections.Generic;
using UltraWorldAI;

namespace UltraWorldAI.Language;

public static class LanguagePersonalitySystem
{
    private static readonly Dictionary<string, Dictionary<string, float>> TraitMap = new()
    {
        ["Irith"] = new() { ["Abertura"] = 0.05f },
        ["Thal"] = new() { ["Conscienciosidade"] = 0.05f }
    };

    public static void ApplyTraits(Person person, string language)
    {
        if (!TraitMap.TryGetValue(language, out var adjustments))
            return;
        foreach (var pair in adjustments)
            person.Mind.Personality.AdjustTrait(pair.Key, pair.Value);
    }
}
