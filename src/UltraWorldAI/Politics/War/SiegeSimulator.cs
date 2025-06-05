using System;

namespace UltraWorldAI.Politics.War;

public static class SiegeSimulator
{
    public static bool SimulateSiege(string attacker, string defender)
    {
        var rand = new Random();
        return rand.NextDouble() > 0.5;
    }
}
