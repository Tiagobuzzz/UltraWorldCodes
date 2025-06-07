using System.Collections.Generic;
using UltraWorldAI.Relationships;
using Xunit;

public class CulturalSexualitySystemTests
{
    [Fact]
    public void DefineNormsAddsCulture()
    {
        CulturalSexualitySystem.Norms.Clear();
        CulturalSexualitySystem.DefineNorms(
            "Velarianos",
            "Casamento ritual",
            new List<string> { "Toque de almas" },
            "Heranca espiritual");

        Assert.Contains(CulturalSexualitySystem.Norms,
            n => n.Culture == "Velarianos" && n.UnionModel == "Casamento ritual");
    }
}
