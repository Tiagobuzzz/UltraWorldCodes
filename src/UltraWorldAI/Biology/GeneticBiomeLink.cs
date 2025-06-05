using System.Collections.Generic;

namespace UltraWorldAI.Biology;

public static class GeneticBiomeLink
{
    public static void MutateCreatures(List<Creature> creatures, string biome)
    {
        foreach (var creature in creatures)
        {
            if (creature.Biome != biome)
                continue;

            if (biome == "Deserto Vazio")
                creature.Traits.Add("Reserva de \u00E1gua corporal");

            if (biome == "Floresta Sombria")
                creature.Traits.Add("Vis\u00E3o noturna");

            if (biome == "Montanha Cantante")
                creature.Traits.Add("Pulm\u00F5es expandidos");

            creature.DNA += "-M";
        }
    }
}
