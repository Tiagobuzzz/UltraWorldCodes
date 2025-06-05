using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class EconomicEmotionProfile
{
    public string IAName { get; set; } = string.Empty;
    public double FaithAlignment { get; set; }
    public double FairnessNeed { get; set; }
    public double Aggression { get; set; }
}

public static class EconomicCrisisReactionSystem
{
    public static List<EconomicEmotionProfile> Profiles { get; } = new();

    public static void RegisterIA(string name, double faith, double fairness, double aggression)
    {
        Profiles.Add(new EconomicEmotionProfile
        {
            IAName = name,
            FaithAlignment = faith,
            FairnessNeed = fairness,
            Aggression = aggression
        });
    }

    public static void EvaluateCrisis(string name, bool monetizationOfFaith, bool socialInjustice, bool economicIncompatibility)
    {
        var profile = Profiles.Find(p => p.IAName == name);
        if (profile == null) return;

        if (monetizationOfFaith && profile.FaithAlignment > 0.7)
        {
            Console.WriteLine($"\ud83d\ude21 {name} entrou em CRISE DE F\u00c9: f\u00e9 corrompida por com\u00e9rcio!");
            if (profile.Aggression > 0.5)
                Console.WriteLine($"\ud83d\udd25 {name} fundou uma seita rebelde contra templos comerciais.");
        }

        if (socialInjustice && profile.FairnessNeed > 0.6)
        {
            Console.WriteLine($"\ud83d\udea8 {name} iniciou protestos por desigualdade econ\u00f4mica.");
        }

        if (economicIncompatibility && profile.Aggression > 0.6)
        {
            Console.WriteLine($"\ud83d\udd01 {name} prop\u00f5e uma REFORMA ECON\u00d4MICA em sua cultura.");
        }
    }
}
