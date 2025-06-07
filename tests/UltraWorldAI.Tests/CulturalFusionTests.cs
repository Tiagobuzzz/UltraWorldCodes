using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CulturalFusionTests
{
    [Fact]
    public void FuseCulturesCombinesData()
    {
        var a = new Culture
        {
            Name = "A",
            CoreValues = new List<string> { "Respeito" },
            Taboos = new List<string> { "Mentir" },
            Traditions = new List<CulturalTradition> { new() { Name = "Saudacao", Rituals = new List<RitualInstance>() } },
            AestheticStyle = "Classico",
            CalendarType = CalendarType.Lunar,
            AssociatedIdeas = new List<string> { "IdeiaA" },
            CulturalCalendar = CalendarBuilder.CreateCalendar(CalendarType.Lunar)
        };
        var b = new Culture
        {
            Name = "B",
            CoreValues = new List<string> { "Honra" },
            Taboos = new List<string> { "Mentir" },
            Traditions = new List<CulturalTradition> { new() { Name = "Cerimonia", Rituals = new List<RitualInstance>() } },
            AestheticStyle = "Moderno",
            CalendarType = CalendarType.Solar,
            AssociatedIdeas = new List<string> { "IdeiaB" },
            CulturalCalendar = CalendarBuilder.CreateCalendar(CalendarType.Solar)
        };

        var fused = CulturalFusion.FuseCultures(a, b);

        Assert.Equal("A-B (Fusão)", fused.Name);
        Assert.Contains("Respeito", fused.CoreValues);
        Assert.Contains("Honra", fused.CoreValues);
        Assert.Single(fused.Taboos, t => t == "Mentir");
        Assert.Contains(fused.Traditions, t => t.Name == "Saudacao");
        Assert.Contains(fused.Traditions, t => t.Name == "Cerimonia");
        Assert.Equal("Classico fundida com Moderno", fused.AestheticStyle);
    }

    [Fact]
    public void DescribeFusionReturnsSummary()
    {
        var culture = new Culture { Name = "Uni" };
        var desc = CulturalFusion.DescribeFusion(culture);
        Assert.Contains("Uni", desc);
    }
}
