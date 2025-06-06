using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticStructure
{
    public string Language { get; set; } = string.Empty;
    public string TimeView { get; set; } = string.Empty; // "C\u00edclico", "Linear", "Fragmentado"
    public string EmotionStyle { get; set; } = string.Empty; // "Expl\u00edcito", "Contido", "Simbolizado"
    public string ActionFocus { get; set; } = string.Empty; // "Verbo", "Estado", "Rela\u00e7\u00e3o"
    public string CognitiveEffect { get; set; } = string.Empty; // "Empatia", "Agressividade", etc.
}

public class IALinguisticPersonality
{
    public string IAName { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public List<string> Traits { get; set; } = new();
}

public static class LinguisticPersonalityInfluenceSystem
{
    public static readonly List<LinguisticStructure> LanguageTraits = new();
    public static readonly List<IALinguisticPersonality> Profiles = new();

    public static void DefineStructure(string language, string time, string emotion, string action, string effect)
    {
        LanguageTraits.Add(new LinguisticStructure
        {
            Language = language,
            TimeView = time,
            EmotionStyle = emotion,
            ActionFocus = action,
            CognitiveEffect = effect
        });

        Console.WriteLine($"\uD83E\uDDE0 Estrutura definida para {language}: Tempo: {time}, Emo\u00e7\u00e3o: {emotion}, A\u00e7\u00e3o: {action} \u2192 Afeta: {effect}");
    }

    public static void AssignToIA(string ia, string language)
    {
        var traits = LanguageTraits.Find(l => l.Language == language);
        if (traits == null) return;

        Profiles.Add(new IALinguisticPersonality
        {
            IAName = ia,
            Language = language,
            Traits = new List<string>
            {
                $"Tempo: {traits.TimeView}",
                $"Emo\u00e7\u00e3o: {traits.EmotionStyle}",
                $"A\u00e7\u00e3o: {traits.ActionFocus}",
                $"Tend\u00eancia: {traits.CognitiveEffect}"
            }
        });

        Console.WriteLine($"\uD83E\uDDEC {ia} teve sua personalidade influenciada pela l\u00edngua {language}.");
    }

    public static void PrintProfile(string ia)
    {
        var p = Profiles.Find(p => p.IAName == ia);
        if (p != null)
        {
            Console.WriteLine($"\n\uD83E\uDDE0 Perfil Lingu\u00edstico de {ia} | L\u00edngua: {p.Language}");
            foreach (var t in p.Traits)
                Console.WriteLine($"\uD83D\uDD39 {t}");
        }
    }
}
