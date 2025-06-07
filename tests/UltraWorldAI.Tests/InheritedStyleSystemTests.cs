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
}
