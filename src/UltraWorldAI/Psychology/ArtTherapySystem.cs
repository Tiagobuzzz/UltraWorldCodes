using System;
using System.Collections.Generic;

namespace UltraWorldAI.Psychology;

public class ArtTherapySession
{
    public string AIName = string.Empty;
    public string ArtTitle = string.Empty;
    public string Emotion = string.Empty;
}

public static class ArtTherapySystem
{
    public static List<ArtTherapySession> Sessions { get; } = new();

    public static void Heal(DefenseMechanismSystem defenses, string aiName, string emotion, string artTitle)
    {
        if (defenses.IsEmotionBlocked(emotion))
        {
            defenses.ActiveDefenses.Remove("anestesia emocional");
            Sessions.Add(new ArtTherapySession
            {
                AIName = aiName,
                ArtTitle = artTitle,
                Emotion = emotion
            });
            Console.WriteLine($"\uD83E\uDDE0 {artTitle} curou bloqueio de {emotion} em {aiName}");
        }
    }
}
