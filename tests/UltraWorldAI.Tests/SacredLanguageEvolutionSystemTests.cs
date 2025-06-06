using UltraWorldAI.Language;
using Xunit;

public class SacredLanguageEvolutionSystemTests
{
    [Fact]
    public void EvolveReturnsHeresyWhenFormUnknown()
    {
        SacredLanguageEvolutionSystem.Languages.Clear();
        SacredLanguageEvolutionSystem.Register("Irith", new[] { "forma1" });
        var heresy = SacredLanguageEvolutionSystem.Evolve("Irith", "forma2");
        Assert.True(heresy);
    }
}
