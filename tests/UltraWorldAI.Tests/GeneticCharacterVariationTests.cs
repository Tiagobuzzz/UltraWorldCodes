using UltraWorldAI.Biology;
using Xunit;

public class GeneticCharacterVariationTests
{
    [Fact]
    public void FromGenomeProducesExpectedTraits()
    {
        var g = new Genome();
        g.Genes.Add(new Gene { Trait = "Hair", AlleleA = "D", AlleleB = "d", ExpressionType = AlleleType.Dominant });
        g.Genes.Add(new Gene { Trait = "Eye", AlleleA = "X", AlleleB = "x", ExpressionType = AlleleType.Dominant });
        g.Genes.Add(new Gene { Trait = "Height", AlleleA = "t", AlleleB = "T", ExpressionType = AlleleType.Dominant });

        var v = GeneticCharacterVariation.FromGenome(g);
        Assert.Equal("Preto", v.HairColor);
        Assert.Equal("Castanho", v.EyeColor);
        Assert.Equal("Alto", v.Height);
    }
}
