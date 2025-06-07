using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class EmotionSpell
{
    public string Emotion = string.Empty; // "Raiva", "Luto", "Amor", etc.
    public string Symbol = string.Empty; // Ex: "Cora\u00E7\u00E3o partido", "M\u00E1scara quebrada"
    public string Effect = string.Empty; // "Explos\u00E3o", "Ilus\u00E3o", "Transmuta\u00E7\u00E3o", etc.
}

public static class EmotionalMagicSystem
{
    public static List<EmotionSpell> Spells { get; } = new();

    public static void CreateEmotionSpell(string emotion, string symbol, string effect)
    {
        Spells.Add(new EmotionSpell
        {
            Emotion = emotion,
            Symbol = symbol,
            Effect = effect
        });

        Console.WriteLine($"\uD83E\uDD16 Magia emocional: {emotion} + {symbol} \u2192 {effect}");
    }

    public static void PrintEmotionSpells()
    {
        foreach (var e in Spells)
            Console.WriteLine($"\n\uD83D\uDD25 {e.Emotion} | S\u00EDmbolo: {e.Symbol} | Efeito: {e.Effect}");
    }
}
