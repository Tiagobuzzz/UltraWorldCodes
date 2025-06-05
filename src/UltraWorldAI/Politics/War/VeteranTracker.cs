using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics.War;

public class VeteranArmy
{
    public string ArmyName { get; set; } = string.Empty;
    public int ExperienceLevel { get; set; }
}

public static class VeteranTracker
{
    public static Dictionary<string, VeteranArmy> Veterans { get; } = new();

    public static void RegisterVictory(string armyName)
    {
        if (!Veterans.ContainsKey(armyName))
        {
            Veterans[armyName] = new VeteranArmy { ArmyName = armyName, ExperienceLevel = 1 };
        }
        else
        {
            Veterans[armyName].ExperienceLevel++;
        }

        Console.WriteLine($"\uD83D\uDEE1️ Tropas de {armyName} ganharam EXP. Nível atual: {Veterans[armyName].ExperienceLevel}");
    }

    public static int GetExperienceBonus(string armyName)
    {
        return Veterans.ContainsKey(armyName) ? Veterans[armyName].ExperienceLevel * 2 : 0;
    }
}
