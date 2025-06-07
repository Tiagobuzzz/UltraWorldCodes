using System.Collections.Generic;
using UltraWorldAI.Relationships;
using Xunit;

public class AttractionAndRomanceSystemTests
{
    [Fact]
    public void RegisterAttractionAddsProfile()
    {
        AttractionAndRomanceSystem.Profiles.Clear();
        AttractionAndRomanceSystem.RegisterAttraction(
            "Kael",
            new Dictionary<string, float> { { "Courage", 0.8f } },
            new List<string> { "Saved Saren" },
            "Passionate");

        Assert.Contains(AttractionAndRomanceSystem.Profiles,
            p => p.Name == "Kael" && p.RomanticState == "Passionate");
    }
}
