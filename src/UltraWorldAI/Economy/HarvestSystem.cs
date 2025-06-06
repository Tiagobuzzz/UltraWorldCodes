using System;

namespace UltraWorldAI.Economy;

/// <summary>
/// Basic crop yield and famine simulation.
/// </summary>
public class HarvestSystem
{
    public int StoredFood { get; private set; }

    public void SimulateHarvest(int yield)
    {
        StoredFood += yield;
    }

    public void Consume(int population)
    {
        StoredFood -= population;
        if (StoredFood < 0)
        {
            Console.WriteLine("\u26A0\uFE0F Fome alastra pela região!");
            StoredFood = 0;
        }
    }
}
