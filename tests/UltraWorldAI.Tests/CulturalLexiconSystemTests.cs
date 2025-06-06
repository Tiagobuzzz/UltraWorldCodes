using UltraWorldAI.Language;
using Xunit;

public class CulturalLexiconSystemTests
{
    [Fact]
    public void CreateLexiconRegistersCulture()
    {
        CulturalLexiconSystem.Lexicons.Clear();
        CulturalLexiconSystem.CreateLexicon("A", "Lang");
        Assert.Single(CulturalLexiconSystem.Lexicons);
    }

    [Fact]
    public void AddWordStoresEntry()
    {
        CulturalLexiconSystem.Lexicons.Clear();
        CulturalLexiconSystem.CreateLexicon("A", "Lang");
        CulturalLexiconSystem.AddWord("A", "love", "amor");
        var lex = CulturalLexiconSystem.Lexicons[0];
        Assert.Equal("amor", lex.MeaningToWord["love"]);
    }
}
