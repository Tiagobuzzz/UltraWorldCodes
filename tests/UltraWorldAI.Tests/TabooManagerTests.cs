using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class TabooManagerTests
{
    [Fact]
    public void AddTabooDoesNotDuplicate()
    {
        var culture = new Culture { Name = "Teste" };
        TabooManager.AddTaboo(culture, "Falar o nome dos mortos");
        TabooManager.AddTaboo(culture, "Falar o nome dos mortos");
        Assert.Single(culture.Taboos);
    }

    [Fact]
    public void MutateTaboosTransformsAndAdds()
    {
        var culture = new Culture
        {
            Name = "Mutante",
            Taboos = new List<string> { "pronunciar o nome sagrado" }
        };
        TabooManager.MutateTaboos(culture);
        Assert.Contains("eco de identidade", culture.Taboos[0]);
        Assert.Contains("Tocar o silêncio ritual", culture.Taboos);
    }

    [Fact]
    public void DescribeTaboosListsTaboos()
    {
        var culture = new Culture { Name = "Narrativa" };
        TabooManager.AddTaboo(culture, "Beber em jejum");
        var desc = TabooManager.DescribeTaboos(culture);
        Assert.Contains("Beber em jejum", desc);
        Assert.Contains("Narrativa", desc);
    }
}
