using UltraWorldAI.Language;
using Xunit;

public class LanguageHeritageSystemTests
{
    [Fact]
    public void SuppressLanguageMarksHeritage()
    {
        LanguageHeritageSystem.Heritages.Clear();
        LanguageHeritageSystem.RegisterHeritage("C", "L1", 0.8);
        LanguageHeritageSystem.SuppressLanguage("C");
        var heritage = LanguageHeritageSystem.Heritages.Find(h => h.Culture == "C");
        Assert.True(heritage?.IsSuppressed);
    }
}
