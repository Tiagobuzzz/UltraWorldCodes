using UltraWorldAI.Knowledge;
using Xunit;

public class ManuscriptSystemTests
{
    [Fact]
    public void CreateAddsToLibrary()
    {
        ManuscriptSystem.Library.Clear();
        ManuscriptSystem.Create("Arcana Maior", "Kael", "Grim\u00f3rio", 1200, true);
        Assert.Single(ManuscriptSystem.Library);
    }
}
