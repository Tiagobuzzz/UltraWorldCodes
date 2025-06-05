using System;

namespace UltraWorldAI.Biology;

public static class GeoBiomePressure
{
    public static void ApplyPressure(Genome genome, World.RegionTopology topo, World.WorldRegion region)
    {
        foreach (var gene in genome.Genes)
        {
            if (topo.Altitude > 3000 && gene.Trait == "Respiração")
            {
                gene.AlleleA = "E";
                gene.AlleleB = "E";
            }

            if (region.Climate == "Úmido" && gene.Trait == "Pele")
            {
                gene.AlleleA = "R";
                gene.AlleleB = "R";
            }

            if (region.Biome.Contains("Manguezal") && gene.Trait == "Mobilidade")
            {
                gene.AlleleA = "M";
            }
        }
    }
}
