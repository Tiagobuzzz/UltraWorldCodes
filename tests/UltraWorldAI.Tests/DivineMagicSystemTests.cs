using UltraWorldAI.Magic;
using Xunit;

public class DivineMagicSystemTests
{
    [Fact]
    public void AddDeityAddsEntry()
    {
        DivineMagicSystem.Deities.Clear();
        DivineMagicSystem.AddDeity("Sol", "Fogo", "Purifica");
        Assert.Contains(DivineMagicSystem.Deities, d => d.DeityName == "Sol");
    }
}
