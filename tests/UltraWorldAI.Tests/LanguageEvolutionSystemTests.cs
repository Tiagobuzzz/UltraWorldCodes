using UltraWorldAI.Language;
using Xunit;

public class LanguageEvolutionSystemTests
{
    [Fact]
    public void EvolveAddsPhoneme()
    {
        var seed = new LanguageSeed { Name = "Test" };
        int before = seed.Phonemes.Count;
        LanguageEvolutionSystem.Evolve(seed);
        Assert.True(seed.Phonemes.Count >= before);
    }
}

