using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CultureOriginStoryTests
{
    [Fact]
    public void CreateCultureIncludesOriginStory()
    {
        var system = new CultureSystem();
        var culture = system.CreateCultureFromIdea("Inovacao", new List<string> { "Criatividade" });
        Assert.False(string.IsNullOrWhiteSpace(culture.OriginStory));
    }
}
