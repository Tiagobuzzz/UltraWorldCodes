using System;
using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CulturalCollapseTests
{
    [Fact]
    public void CheckCollapseDetectsEntropy()
    {
        var culture = new Culture
        {
            Taboos = new List<string> { "Honra" },
            Traditions = new List<Tradition> { new() { Name = "T", Rituals = new List<RitualInstance>() } }
        };

        Assert.True(CulturalCollapse.CheckCollapse(culture));

        var stable = new Culture
        {
            CoreValues = new List<string> { "Honra" },
            Traditions = new List<Tradition> { new() { Name = "R", Rituals = new List<RitualInstance> { new() { Name = "Cerimonia", Date = DateTime.Now, EmotionTone = "alegre", PerformedBy = "tester" } } } }
        };

        Assert.False(CulturalCollapse.CheckCollapse(stable));
    }

    [Fact]
    public void CollapseCultureClearsData()
    {
        var culture = new Culture
        {
            Name = "Memoria",
            CoreValues = new List<string> { "Valor" },
            Traditions = new List<Tradition> { new() { Name = "R", Rituals = new List<RitualInstance> { new() { Name = "Cerimonia", Date = DateTime.Now, EmotionTone = "intenso", PerformedBy = "x" } } } },
            Taboos = new List<string> { "Valor" },
            AssociatedIdeas = new List<string>()
        };

        CulturalCollapse.CollapseCulture(culture);

        Assert.Contains("(Extinta)", culture.Name);
        Assert.Empty(culture.CoreValues);
        Assert.Empty(culture.Traditions);
        Assert.Empty(culture.Taboos);
        Assert.Contains("Desintegração cultural", culture.AssociatedIdeas);
        Assert.Equal("Ruína da memória", culture.AestheticStyle);
    }

    [Fact]
    public void DescribeCollapseMentionsCulture()
    {
        var culture = new Culture { Name = "Arcadia" };
        var desc = CulturalCollapse.DescribeCollapse(culture);
        Assert.Contains("Arcadia", desc);
    }
}
