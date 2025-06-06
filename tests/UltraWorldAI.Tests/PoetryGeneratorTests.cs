using UltraWorldAI.Literature;
using Xunit;

public class PoetryGeneratorTests
{
    [Fact]
    public void GeneratePoemIncludesTheme()
    {
        var poem = PoetryGenerator.GeneratePoem("amor");
        Assert.Contains("amor", poem);
    }
}
