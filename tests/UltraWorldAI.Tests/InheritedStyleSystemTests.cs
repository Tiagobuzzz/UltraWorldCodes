using System.Collections.Generic;
using UltraWorldAI.Module15;
using Xunit;

public class InheritedStyleSystemTests
{
    [Fact]
    public void AddStyleRegistersStyle()
    {
        InheritedStyleSystem.Styles.Clear();
        InheritedStyleSystem.AddStyle("Tribo", "Simbolo", new List<string>{"Roupas"});
        Assert.Contains(InheritedStyleSystem.Styles, s => s.Culture == "Tribo" && s.AestheticSymbol == "Simbolo" && s.InfluencedTraits.Contains("Roupas"));
    }

    [Fact]
    public void InheritCopiesParentStyle()
    {
        InheritedStyleSystem.Styles.Clear();
        InheritedStyleSystem.AddStyle("Pai", "Totem", new List<string>{"Música"});
        InheritedStyleSystem.Inherit("Pai", "Filho");
        Assert.Contains(InheritedStyleSystem.Styles, s => s.Culture == "Filho" && s.AestheticSymbol == "Totem");
    }
}
