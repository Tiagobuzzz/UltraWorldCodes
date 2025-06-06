using System.Collections.Generic;
using UltraWorldAI.Language;
using Xunit;

public class LinguisticConflictSystemTests
{
    [Fact]
    public void EnforceLanguageIncreasesTension()
    {
        LinguisticConflictSystem.Regions.Clear();
        LinguisticConflictSystem.AddRegion("Empire", new List<string> { "A", "B" }, "A");
        LinguisticConflictSystem.EnforceLanguage("Empire", "A");
        var region = LinguisticConflictSystem.Regions.Find(r => r.Empire == "Empire");
        Assert.True(region!.Tensions["B"] > 0.5);
    }
}
