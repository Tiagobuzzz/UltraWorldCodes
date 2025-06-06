using System;

namespace UltraWorldAI.Politics.War;

public static class RealTimeBattleAI
{
    public static string SimulateBattle(string attacker, double attackerStrength, string defender, double defenderStrength)
    {
        var rand = new Random();
        double tacticalFactor = rand.NextDouble() * 0.2 - 0.1; // -0.1 a 0.1
        attackerStrength += attackerStrength * tacticalFactor;
        defenderStrength += defenderStrength * -tacticalFactor;
        return attackerStrength >= defenderStrength ? attacker : defender;
    }
}
