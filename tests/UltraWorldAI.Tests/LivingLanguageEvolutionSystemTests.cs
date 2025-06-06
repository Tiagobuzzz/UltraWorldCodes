using UltraWorldAI.Language;
using Xunit;

public class LivingLanguageEvolutionSystemTests
{
    [Fact]
    public void MutateWordMaintainsLength()
    {
        var result = LanguageEvolutionSystem.MutateWord("test");
        Assert.Equal(4, result.Length);
    }

    [Fact]
    public void MutateLexiconPreservesKeys()
    {
        CulturalLexiconSystem.Lexicons.Clear();
        CulturalLexiconSystem.CreateLexicon("C", "Lang");
        CulturalLexiconSystem.AddWord("C", "hi", "hola");
        LanguageEvolutionSystem.MutateLexicon("C");
        var lex = CulturalLexiconSystem.Lexicons[0];
        Assert.Contains("hi", lex.MeaningToWord.Keys);
    }
}
