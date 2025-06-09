using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class TradeMemory
{
    public string IAName { get; set; } = string.Empty;
    public List<string> SuccessfulGoods { get; } = new();
    public List<string> FailedGoods { get; } = new();
    public int ExperienceLevel { get; set; }
}

public static class AdaptiveTradeAI
{
    public static List<TradeMemory> Profiles { get; } = new();

    public static void Register(string name)
    {
        Profiles.Add(new TradeMemory { IAName = name });
    }

    public static void RecordTrade(string name, string good, bool success)
    {
        var profile = Profiles.Find(p => p.IAName == name);
        if (profile == null) return;

        if (success)
        {
            if (!profile.SuccessfulGoods.Contains(good))
                profile.SuccessfulGoods.Add(good);
            profile.ExperienceLevel++;
        }
        else
        {
            if (!profile.FailedGoods.Contains(good))
                profile.FailedGoods.Add(good);
            profile.ExperienceLevel--;
        }

        Console.WriteLine($"\uD83E\uDD16 {name} aprendeu com o trade de {good}: {(success ? "sucesso" : "falha")}");
    }

    public static string RecommendNextGood(string name)
    {
        var profile = Profiles.Find(p => p.IAName == name);
        if (profile == null || profile.SuccessfulGoods.Count == 0) return "Aleatório";

        return profile.SuccessfulGoods[RandomSingleton.Shared.Next(profile.SuccessfulGoods.Count)];
    }
}
