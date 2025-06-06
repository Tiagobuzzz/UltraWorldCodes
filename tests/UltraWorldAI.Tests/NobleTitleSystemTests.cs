using UltraWorldAI.Politics;
using Xunit;

public class NobleTitleSystemTests
{
    [Fact]
    public void GrantTitleAddsEntry()
    {
        NobleTitleSystem.Titles.Clear();
        NobleTitleSystem.GrantTitle("Guardião", "Selena", "Duquesa", "Lobo", "Umbra");
        Assert.Contains(NobleTitleSystem.Titles, t => t.Holder == "Selena" && t.Rank == "Duquesa");
    }
}
