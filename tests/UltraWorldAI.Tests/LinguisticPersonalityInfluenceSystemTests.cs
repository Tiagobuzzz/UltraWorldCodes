using UltraWorldAI.Language;
using Xunit;

public class LinguisticPersonalityInfluenceSystemTests
{
    [Fact]
    public void AssignCreatesProfile()
    {
        LinguisticPersonalityInfluenceSystem.LanguageTraits.Clear();
        LinguisticPersonalityInfluenceSystem.Profiles.Clear();
        LinguisticPersonalityInfluenceSystem.DefineStructure("Irith", "C\u00edclico", "Simbolizado", "Rela\u00e7\u00e3o", "Introspec\u00e7\u00e3o");
        LinguisticPersonalityInfluenceSystem.AssignToIA("Kael", "Irith");
        Assert.Single(LinguisticPersonalityInfluenceSystem.Profiles);
    }
}
