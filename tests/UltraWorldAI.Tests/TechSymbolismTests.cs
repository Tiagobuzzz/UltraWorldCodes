using UltraWorldAI.Discovery;
using Xunit;

public class TechSymbolismTests
{
    [Fact]
    public void CodifyAddsSymbolicStatus()
    {
        TechSymbolism.Codified.Clear();
        TechSymbolism.Codify("Tec-A", "Manual", "Tribo");

        Assert.Single(TechSymbolism.Codified);
        Assert.Equal("Manual", TechSymbolism.Codified[0].SymbolicForm);
    }
}
