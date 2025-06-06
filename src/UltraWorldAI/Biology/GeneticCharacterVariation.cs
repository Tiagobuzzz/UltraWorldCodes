using System.Collections.Generic;
using System;

namespace UltraWorldAI.Biology;

public class CharacterVariation
{
    public string HairColor { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
}

public static class GeneticCharacterVariation
{
    public static CharacterVariation FromGenome(Genome genome)
    {
        var variation = new CharacterVariation();
        foreach (var gene in genome.Genes)
        {
            var expressed = gene.Expressed();
            if (gene.Trait == "Hair")
                variation.HairColor = expressed == "D" ? "Preto" : "Loiro";
            else if (gene.Trait == "Eye")
                variation.EyeColor = expressed == "X" ? "Castanho" : "Azul";
            else if (gene.Trait == "Height")
                variation.Height = expressed == "T" ? "Alto" : "Baixo";
        }
        return variation;
    }
}
