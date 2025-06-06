using UltraWorldAI.Language;
using Xunit;

public class LinguisticArchitectureInfluenceSystemTests
{
    [Fact]
    public void DefineInfluenceAddsDesign()
    {
        LinguisticArchitectureInfluenceSystem.Designs.Clear();
        LinguisticArchitectureInfluenceSystem.DefineInfluence("Nova", "Irith", "Arcos", "Runas", "C\u00f3smos c\u00edclico");
        Assert.Single(LinguisticArchitectureInfluenceSystem.Designs);
    }
}
