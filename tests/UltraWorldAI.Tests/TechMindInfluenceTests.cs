using UltraWorldAI.Mental;
using Xunit;

public class TechMindInfluenceTests
{
    [Fact]
    public void ApplyTechInfluenceStoresTraits()
    {
        TechMindInfluence.CognitiveTraits.Clear();
        TechMindInfluence.ApplyTechInfluence("id", "Tecnocracia Alfa");
        Assert.True(TechMindInfluence.CognitiveTraits.ContainsKey("id"));
        string desc = TechMindInfluence.Describe("id");
        Assert.Contains("Tra\u00e7os mentais", desc);
    }
}
