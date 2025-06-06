using UltraWorldAI.Mythology;
using Xunit;

public class MythGeneratorTests
{
    [Fact]
    public void GenerateLegendReturnsText()
    {
        var legend = MythGenerator.GenerateLegend();
        Assert.Contains("Lenda", legend);
    }
}
