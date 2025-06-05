using System;
using System.Collections.Generic;
using UltraWorldAI.Civilization;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public class WarHero
{
    public string Name { get; set; } = string.Empty;
    public string FromSettlement { get; set; } = string.Empty;
    public string Feat { get; set; } = string.Empty;
    public int FameLevel { get; set; }
}

public static class WarHeroSystem
{
    public static List<WarHero> Heroes { get; } = new();

    public static void GenerateHero(SapientBeing being, string feat)
    {
        if (being == null) return;
        var hero = new WarHero
        {
            Name = being.Name,
            FromSettlement = being.CurrentRegion,
            Feat = feat,
            FameLevel = 1
        };

        Heroes.Add(hero);
        SettlementHistoryTracker.Register(being.CurrentRegion, "Herói Emergente", $"{being.Name}: {feat}");
    }

    public static void LevelUpHero(string name)
    {
        var hero = Heroes.Find(h => h.Name == name);
        if (hero == null) return;

        hero.FameLevel++;
        Console.WriteLine($"\u2728 {hero.Name} agora é Lenda Militar! Nível de Fama: {hero.FameLevel}");
    }
}
