using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics.War;

public class WarDoctrine
{
    public string Name { get; set; } = string.Empty;
    public string Effect { get; set; } = string.Empty;
}

public class WarHeroAura
{
    public string HeroName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Moral, Ataque, Defesa, Inspiração
    public int Radius { get; set; }
    public int BoostAmount { get; set; }
}

public class MagicalEspionage
{
    public string TargetArmy { get; set; } = string.Empty;
    public string SpellUsed { get; set; } = string.Empty; // Revelação, Corrupção, Fogo Silencioso
    public bool Successful { get; set; }
}

public static class DoctrinalWarSystem
{
    public static List<WarDoctrine> Doctrines { get; } = new()
    {
        new WarDoctrine { Name = "Sacrifício", Effect = "Buff moral extremo com risco de perda" },
        new WarDoctrine { Name = "Conversão", Effect = "Chance de corromper tropas inimigas" },
        new WarDoctrine { Name = "Punição", Effect = "Dano adicional contra exércitos impuros" },
        new WarDoctrine { Name = "Proteção", Effect = "Imunidade parcial a feitiços" }
    };

    public static WarDoctrine GetDoctrineForArmy(string beliefSystem)
    {
        return beliefSystem switch
        {
            "Purificação" => Doctrines.Find(d => d.Name == "Punição")!,
            "Equilíbrio" => Doctrines.Find(d => d.Name == "Proteção")!,
            "Expansão" => Doctrines.Find(d => d.Name == "Conversão")!,
            _ => Doctrines.Find(d => d.Name == "Sacrifício")!
        };
    }

    public static WarHeroAura GetAuraFromHero(WarHero hero)
    {
        return new WarHeroAura
        {
            HeroName = hero.Name,
            Type = hero.FameLevel switch
            {
                >= 5 => "Inspiração",
                >= 3 => "Moral",
                _ => "Defesa"
            },
            Radius = 3 + hero.FameLevel,
            BoostAmount = hero.FameLevel * 2
        };
    }

    public static MagicalEspionage AttemptSpell(string targetArmy)
    {
        var rand = RandomSingleton.Shared;
        string spell = rand.NextDouble() switch
        {
            < 0.3 => "Revelação",
            < 0.6 => "Corrupção",
            _ => "Fogo Silencioso"
        };

        return new MagicalEspionage
        {
            TargetArmy = targetArmy,
            SpellUsed = spell,
            Successful = rand.NextDouble() < 0.5
        };
    }
}
