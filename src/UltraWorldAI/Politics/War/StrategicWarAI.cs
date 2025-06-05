using System;
using UltraWorldAI.Civilization;

namespace UltraWorldAI.Politics.War;

public static class StrategicWarAI
{
    public static string DecideAction(SapientBeing ia, War war)
    {
        string personality = ia.PersonalityType?.ToLower() ?? string.Empty;
        var rand = new Random();

        if (personality.Contains("impulsivo"))
            return rand.NextDouble() < 0.7 ? "Atacar direto" : "Grito de guerra";
        if (personality.Contains("paranoico"))
            return rand.NextDouble() < 0.6 ? "Recuar" : "Armar emboscada";
        if (personality.Contains("pacifista"))
            return rand.NextDouble() < 0.8 ? "Negociar trégua" : "Espionar silenciosamente";
        if (personality.Contains("calculista"))
            return rand.NextDouble() < 0.7 ? "Sabotar suprimentos" : "Espionar líderes";

        return "Atuar conforme cultura militar";
    }
}
