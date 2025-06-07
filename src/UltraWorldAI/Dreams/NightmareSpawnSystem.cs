using System.Collections.Generic;
using UltraWorldAI.World.Creation;

namespace UltraWorldAI.Dreams;

public static class NightmareSpawnSystem
{
    public static void SpawnMonster(Dream dream)
    {
        if (!dream.Emotion.Equals("Medo", System.StringComparison.OrdinalIgnoreCase))
            return;

        var traits = new Dictionary<string, string> { { "Origem", "Pesadelo" } };
        EcosystemGeneticSystem.SpawnCreature($"{dream.Symbol} Monstruoso", dream.Region, traits);
    }
}
