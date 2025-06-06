using UltraWorldAI.Language;
using Xunit;

public class LanguageHeritageSystemTests
{
    [Fact]
    public void RemovingLastLanguageLeavesEmptyList()
    {
        LanguageHeritageSystem.Heritages.Clear();
        LanguageHeritageSystem.AddLanguage("C", "L1");
        LanguageHeritageSystem.RemoveLanguage("C", "L1");
        var heritage = LanguageHeritageSystem.Heritages.Find(h => h.Culture == "C");
        Assert.True(heritage == null || heritage.Languages.Count == 0);
    }
}
