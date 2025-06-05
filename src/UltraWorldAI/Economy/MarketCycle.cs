using System;
using UltraWorldAI.World;

namespace UltraWorldAI.Economy;

public static class MarketCycle
{
    public static void TickMarket(Settlement settlement)
    {
        var rand = new Random();
        settlement.Population += rand.Next(-5, 6);
        if (settlement.Population < 0) settlement.Population = 0;
    }
}
