using UltraWorldAI.Language;
using Xunit;

public class MultilingualMindSystemTests
{
    [Fact]
    public void AnalyzeStateDetectsConflict()
    {
        LinguisticPersonalityInfluenceSystem.LanguageTraits.Clear();
        MultilingualMindSystem.LanguagesByIA.Clear();
        LinguisticPersonalityInfluenceSystem.DefineStructure("Irith", "C\u00edclico", "Simbolizado", "Rela\u00e7\u00e3o", "Introspec\u00e7\u00e3o");
        LinguisticPersonalityInfluenceSystem.DefineStructure("Thal", "Linear", "Expl\u00edcito", "Verbo", "Agressividade");
        MultilingualMindSystem.TeachLanguage("Kael", "Irith");
        MultilingualMindSystem.TeachLanguage("Kael", "Thal");
        Assert.Equal("Conflito Interno", MultilingualMindSystem.AnalyzeState("Kael"));
    }
}
